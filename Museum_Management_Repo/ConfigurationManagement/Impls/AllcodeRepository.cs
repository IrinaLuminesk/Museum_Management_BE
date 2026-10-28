
using DataConnectionFactory.Intfs;
using DTO_Models.ConfigurationManagement;
using DTO_Models.Response;
using Museum_Management_Repositories.ConfigurationManagement.Intfs;

namespace Museum_Management_Repositories.ConfigurationManagement.Impls
{
    public class AllcodeRepository : IAllcodeRepository
    {
   
        private readonly IStoreProcedureFactory _storeprocedureFactory;

        public AllcodeRepository(IStoreProcedureFactory storeprocedureFactory)
        {
            _storeprocedureFactory = storeprocedureFactory;
        }

        public async Task<APIResponse_Model> Allcode_Create(Allcode_model? model)
        {
            var result = await _storeprocedureFactory.Create<Allcode_model>(StoredProcedures.Allcode.ALLCODE_CREATE, model);
            return result;
        }


        public async Task<APIResponse_Model> Allcode_Search(Allcode_model? model)
        {
            return await _storeprocedureFactory.Search<Allcode_model>(StoredProcedures.Allcode.ALLCODE_SEARCH, model);
        }

        public async Task<APIResponse_Model> Allcode_Edit(Allcode_model? model)
        {
            return await _storeprocedureFactory.Edit<Allcode_model>(StoredProcedures.Allcode.ALLCODE_EDIT, model);
        }

        public async Task<APIResponse_Model> Allcode_getbyId(int Allcode_Id)
        {
            return await _storeprocedureFactory.GetbyId<Allcode_model>(StoredProcedures.Allcode.ALLCODE_GETBYID, new { p_Allcode_Id = Allcode_Id });
        }
    }
}
