using DTO_Models.MasterData;
using DTO_Models.Response;

namespace Museum_Management_Services.MasterData.Intfs
{
    public interface IMuseumService
    {
        public Task<APIResponse_Model> Museum_Search(Museum_model? model);
        public Task<APIResponse_Model> Museum_Create(Museum_model? model);

        public Task<APIResponse_Model> Museum_Edit(Museum_model? model);

        public Task<APIResponse_Model> Museum_Delete(string MuseumId);

        public Task<APIResponse_Model> Museum_getbyId(string MuseumId);
    }
}
