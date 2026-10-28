using Dapper;
using DataConnectionFactory.Intfs;
using DTO_Models.MasterData;
using DTO_Models.Response;
using Museum_Management_Repositories.MasterData.Intfs;
using System.Data;
using System.Reflection;
namespace Museum_Management_Repositories.MasterData.Impls
{
    public class MuseumRepository : IMuseumRepository
    {
        //private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IStoreProcedureFactory _storeprocedureFactory;

        public MuseumRepository(IStoreProcedureFactory storeprocedureFactory)
        {
            //_connectionFactory = connectionFactory;
            _storeprocedureFactory = storeprocedureFactory;
        }

        public async Task<APIResponse_Model> Museum_Create(Museum_model? model)
        {
            var result = await _storeprocedureFactory.Create<Museum_model>(StoredProcedures.Museum.MUSEUM_CREATE, model);
            return result;
        }

        public async Task<APIResponse_Model> Museum_Delete(string MuseumId)
        {
            return await _storeprocedureFactory.Delete(StoredProcedures.Museum.MUSEUM_DELETE, new { p_MUSEUM_ID = MuseumId });
        }

        public async Task<APIResponse_Model> Museum_Search(Museum_model? model)
        {
            return await _storeprocedureFactory.Search<Museum_model>(StoredProcedures.Museum.MUSEUM_SEARCH, model);
        }

        public async Task<APIResponse_Model> Museum_Edit(Museum_model? model)
        {
            return await _storeprocedureFactory.Edit<Museum_model>(StoredProcedures.Museum.MUSEUM_EDIT, model);
        }

        public async Task<APIResponse_Model> Museum_getbyId(string MuseumId)
        {
            return await _storeprocedureFactory.GetbyId<Museum_model>(StoredProcedures.Museum.MUSEUM_GETBYID, new { p_MUSEUM_ID = MuseumId });
        }
    }
}
