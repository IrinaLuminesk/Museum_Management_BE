
using Dapper;
using DTO_Models.Response;

namespace DataConnectionFactory.Intfs
{
    public interface IStoreProcedureFactory
    {
        public Task<APIResponse_Model> Search<T>(string storeProcedureName, T? model);
        public Task<APIResponse_Model> Create<T>(string storeProcedureName, T? model);

        public Task<APIResponse_Model> Edit<T>(string storeProcedureName, T? model);

        public Task<APIResponse_Model> Delete(string storeProcedureName, object id);

        public Task<APIResponse_Model> GetbyId<T>(string storeProcedureName, object id);
    }
}
