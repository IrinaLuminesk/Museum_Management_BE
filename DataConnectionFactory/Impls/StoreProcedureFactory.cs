using Dapper;
using DataConnectionFactory.Intfs;
using DTO_Models.MasterData;
using DTO_Models.Response;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectionFactory.Impls
{
    public sealed class StoreProcedureFactory : IStoreProcedureFactory
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public StoreProcedureFactory(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private async Task<DynamicParameters> GetParameters<T>(SqlConnection connection, string storeProcedureName, T? model)
        {
            //Lấy parameter của store procedure
            var paras = (await connection.QueryAsync<string>(
                "GET_STORE_PROCEDURE_PARA",
                new { p_STORE_PROCEDURE_NAME = storeProcedureName },
                commandType: CommandType.StoredProcedure
            )).ToList();

            //Bỏ p_ ra
            var trim_paras = paras.Select(p => p[3..]).ToList();

            var parameters = new DynamicParameters();

            foreach (var property in typeof(T).GetProperties())
            {
                string model_property = property.Name.ToString();
                if (trim_paras.Contains(model_property) == true)
                {
                    parameters.Add($"p_{property.Name}", property.GetValue(model));
                }
            }
            return parameters;
        }

        public async Task<APIResponse_Model> Create<T>(string storeProcedureName, T? model)
        {
            await using var connection = _connectionFactory.CreateConnection();


            var parameters = await GetParameters<T>(connection, storeProcedureName, model);

            var result = await connection.QuerySingleAsync<APIResponse_Model>(
                storeProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<APIResponse_Model> Delete(string storeProcedureName, object id)
        {
            await using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QuerySingleAsync<APIResponse_Model>(
                storeProcedureName,
                id,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }


        public async Task<APIResponse_Model> Edit<T>(string storeProcedureName, T? model)
        {
            return await Create<T>(storeProcedureName, model);
        }

        public async Task<APIResponse_Model> Search<T>(string storeProcedureName, T? model)
        {
            await using var connection = _connectionFactory.CreateConnection();

            var parameters = await GetParameters<T>(connection, storeProcedureName, model);

            var resultList = await connection.QueryMultipleAsync(
                storeProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
                );

            var data = (await resultList.ReadAsync<T>()).ToList();
            var totalRows = await resultList.ReadSingleAsync<int>();

            var result = new APIResponse_Model()
            {
                responseCode = 200,
                responseMessage = "",
                result = new { 
                    data,
                    totalRows
                }

            };
            
            return result;

        }

        public async Task<APIResponse_Model> GetbyId<T>(string storeProcedureName, object id)
        {
            try
            {
                await using var connection = _connectionFactory.CreateConnection();

                var result = await connection.QuerySingleAsync<T>(
                    storeProcedureName,
                    id,
                    commandType: CommandType.StoredProcedure
                );
                return new APIResponse_Model()
                {
                    responseCode = 200,
                    responseMessage = "",
                    result = result
                };
            }
            catch (Exception ex) {
                return new APIResponse_Model()
                {
                    responseCode = 200,
                    responseMessage = "",
                    result = ex.Message
                };
            }
        }
    }
}
