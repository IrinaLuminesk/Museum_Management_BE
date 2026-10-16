using DTO_Models.MasterData;
using DTO_Models.Response;
using Museum_Management_Repositories.MasterData.Intfs;
using Museum_Management_Services.MasterData.Intfs;

namespace Museum_Management_Services.MasterData.Impls
{
    public class MuseumService : IMuseumService
    {
        private readonly IMuseumRepository _museumRepository;

        public MuseumService(IMuseumRepository museumRepository)
        {
            _museumRepository = museumRepository;
        }

        public async Task<APIResponse_Model> Search(Museum_model? model)
        { 
            return await _museumRepository.Search(model);
        }

        public async Task<APIResponse_Model> Add(Museum_model? model)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse_Model> Update(Museum_model? model)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse_Model> Delete(Museum_model? model)
        {
            throw new NotImplementedException();
        }
    }
}
