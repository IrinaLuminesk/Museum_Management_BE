using Dapper;
using DataConnectionFactory.Intfs;
using DTO_Models.MasterData;
using DTO_Models.Response;
using Museum_Management_Repositories.MasterData.Intfs;
using System.Data;
namespace Museum_Management_Repositories.MasterData.Impls
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public MuseumRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<APIResponse_Model> Add(Museum_model? model)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse_Model> Delete(Museum_model? model)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse_Model> Search(Museum_model? model)
        {
            await using var connection = _connectionFactory.CreateConnection();

            var resultList = await connection.QueryAsync<Museum_model>(
                "MuseumSearch",
                new { },
                commandType: CommandType.StoredProcedure
                );
            var result = new APIResponse_Model()
            {
                responseCode = 200,
                responseMessage = "",
                result = resultList.ToList()
            };
            return result;
        }

        public Task<APIResponse_Model> Update(Museum_model? model)
        {
            throw new NotImplementedException();
        }
    }
}
