using DTO_Models.MasterData;
using DTO_Models.Response;

namespace Museum_Management_Repositories.MasterData.Intfs
{
    public interface IMuseumRepository
    {
        public Task<APIResponse_Model> Search(Museum_model? model);
        public Task<APIResponse_Model> Add(Museum_model? model);

        public Task<APIResponse_Model> Update(Museum_model? model);

        public Task<APIResponse_Model> Delete(Museum_model? model);
    }
}
