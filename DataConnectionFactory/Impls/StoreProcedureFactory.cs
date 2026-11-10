using Dapper;
using DataConnectionFactory.Intfs;
using DTO_Models.Response;
using Lottery_Predict_Utilities.FileProcess;
using Microsoft.Data.SqlClient;
using System.Data;

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
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
                );

            var data = (await resultList.ReadAsync<T>()).ToList();
            var totalRows = await resultList.ReadSingleAsync<int>();

            var result = new APIResponse_Model()
            {
                responseCode = 200,
                responseMessage = "",
                result = new
                {
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

                var result = await connection.QueryMultipleAsync(
                    storeProcedureName,
                    id,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 120
                );

                var data = (await result.ReadAsync<T>()).ToList();

                var response = await result.ReadFirstAsync<APIResponse_Model>();
                response.result = data.FirstOrDefault(); ;
                return response;
            }
            catch (Exception ex)
            {
                return new APIResponse_Model()
                {
                    responseCode = 200,
                    responseMessage = "",
                    result = ex.Message
                };
            }
        }

        public async Task<APIResponse_Model> Export<T>(string storeProcedureName, T? model, Export_model param)
        {
            await using var connection = _connectionFactory.CreateConnection();

            var parameters = await GetParameters<T>(connection, storeProcedureName, model);

            var resultList = await connection.QueryMultipleAsync(
                storeProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
                );

            //var data = (await resultList.ReadAsync<T>()).ToList();
            //Đảm bảo headers và data align
            var data = (await resultList.ReadAsync()).Select(row => (IDictionary<string, object>)row).ToList();
            var orderedData = data.Select(row => param.columnId.Select(header => 
            row.TryGetValue(header, out var value) ? value : null).ToList()).ToList();
            var excelData = (await FileHandler.ExportExcel2<T>(param.reportName, param.headers, orderedData));
            var totalRows = await resultList.ReadSingleAsync<int>();

            var result = new APIResponse_Model()
            {
                responseCode = 200,
                responseMessage = "",
                result = new
                {
                    excelData,
                    totalRows
                }

            };

            return result;
        }
    }
}
