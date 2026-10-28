using DTO_Models.ConfigurationManagement;
using DTO_Models.MasterData;
using DTO_Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Museum_Management_Services.ConfigurationManagement.Intfs;

namespace Museum_Management.Controllers.ConfigurationManagement
{
    [Area("ConfigurationManagement")]
    [ApiController]
    [Route("api/[area]/[controller]")]
    public class AllcodeController : ControllerBase
    {
        private readonly IAllcodeService _allcodeService;

        public AllcodeController(IAllcodeService allcodeService)
        {
            _allcodeService = allcodeService;
        }

        [HttpPost("ALLCODE_SEARCH")]
        public async Task<APIResponse_Model> Allcode_Search([FromBody] Allcode_model? model)
        {
            try
            {
                var results = await _allcodeService.Allcode_Search(model);


                return results;
            }
            catch (ArgumentException ex)
            {
                return new APIResponse_Model()
                {
                    responseCode = 500,
                    responseMessage = ex.Message
                };
            }
        }

        [HttpPost("ALLCODE_CREATE")]
        public async Task<APIResponse_Model> Allcode_Create(Allcode_model? model)
        {
            try
            {
                var results = await _allcodeService.Allcode_Create(model);


                return results;
            }
            catch (ArgumentException ex)
            {
                return new APIResponse_Model()
                {
                    responseCode = 500,
                    responseMessage = ex.Message
                };
            }
        }

        [HttpPost("ALLCODE_EDIT")]
        public async Task<APIResponse_Model> Allcode_Edit(Allcode_model? model)
        {
            try
            {
                var results = await _allcodeService.Allcode_Edit(model);


                return results;
            }
            catch (ArgumentException ex)
            {
                return new APIResponse_Model()
                {
                    responseCode = 500,
                    responseMessage = ex.Message
                };
            }
        }

        [HttpPost("ALLCODE_GETBYID")]
        public async Task<APIResponse_Model> Allcode_getbyId(int Allcode_Id)
        {
            try
            {
                var results = await _allcodeService.Allcode_getbyId(Allcode_Id);


                return results;
            }
            catch (ArgumentException ex)
            {
                return new APIResponse_Model()
                {
                    responseCode = 500,
                    responseMessage = ex.Message
                };
            }
        }

    }


}
