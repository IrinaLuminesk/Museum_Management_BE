using DTO_Models.MasterData;
using DTO_Models.Response;
using Museum_Management_Repositories.MasterData.Intfs;
using Museum_Management_Services.MasterData.Intfs;
using System.Reflection;

namespace Museum_Management_Services.MasterData.Impls
{
    public class MuseumService : IMuseumService
    {
        private readonly IMuseumRepository _museumRepository;

        public MuseumService(IMuseumRepository museumRepository)
        {
            _museumRepository = museumRepository;
        }

        public async Task<APIResponse_Model> Museum_Search(Museum_model? model)
        { 
            return await _museumRepository.Museum_Search(model);
        }

        public async Task<APIResponse_Model> Museum_Create(Museum_model? model)
        {
            return await _museumRepository.Museum_Create(model);
        }

        public async Task<APIResponse_Model> Museum_Edit(Museum_model? model)
        {
            return await _museumRepository.Museum_Edit(model);
        }

        public async Task<APIResponse_Model> Museum_Delete(string MuseumId)
        {
            return await _museumRepository.Museum_Delete(MuseumId);
        }

        public async Task<APIResponse_Model> Museum_getbyId(string MuseumId)
        {
            return await _museumRepository.Museum_getbyId(MuseumId);
        }
    }
}
