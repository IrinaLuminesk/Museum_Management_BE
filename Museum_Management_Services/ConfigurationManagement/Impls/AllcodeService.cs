using DTO_Models.ConfigurationManagement;
using DTO_Models.Response;
using Museum_Management_Repositories.ConfigurationManagement.Intfs;

namespace Museum_Management_Services.ConfigurationManagement.Intfs
{
    public class AllcodeService : IAllcodeService
    {
        private readonly IAllcodeRepository _allcodeRepository;

        public AllcodeService(IAllcodeRepository allcodeRepository)
        {
            _allcodeRepository = allcodeRepository;
        }

        public async Task<APIResponse_Model> Allcode_Search(Allcode_model? model)
        { 
            return await _allcodeRepository.Allcode_Search(model);
        }

        public async Task<APIResponse_Model> Allcode_Create(Allcode_model? model)
        {
            return await _allcodeRepository.Allcode_Create(model);
        }

        public async Task<APIResponse_Model> Allcode_Edit(Allcode_model? model)
        {
            return await _allcodeRepository.Allcode_Edit(model);
        }


        public async Task<APIResponse_Model> Allcode_getbyId(int Allcode_Id)
        {
            return await _allcodeRepository.Allcode_getbyId(Allcode_Id);
        }
    }
}
