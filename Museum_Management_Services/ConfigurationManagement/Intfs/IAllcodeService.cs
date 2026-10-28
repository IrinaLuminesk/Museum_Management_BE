using DTO_Models.ConfigurationManagement;
using DTO_Models.Response;

namespace Museum_Management_Services.ConfigurationManagement.Intfs
{
    public interface IAllcodeService
    {
        public Task<APIResponse_Model> Allcode_Search(Allcode_model? model);
        public Task<APIResponse_Model> Allcode_Create(Allcode_model? model);

        public Task<APIResponse_Model> Allcode_Edit(Allcode_model? model);

        public Task<APIResponse_Model> Allcode_getbyId(int Allcode_Id);
    }
}
