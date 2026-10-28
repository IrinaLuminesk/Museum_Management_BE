using DTO_Models.MasterData;
using DTO_Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Museum_Management_Services.MasterData.Intfs;

namespace Museum_Management.Controllers.MasterData
{
    [Area("MasterData")]
    [ApiController]
    [Route("api/[area]/[controller]")]
    public class MuseumController : ControllerBase
    {
        private readonly IMuseumService _museumService;

        public MuseumController(IMuseumService museumService)
        {
            _museumService = museumService;
        }

        [HttpPost("MUSEUM_SEARCH")]
        public async Task<APIResponse_Model> Museum_Search([FromBody] Museum_model? model)
        {
            try
            {
                var results = await _museumService.Museum_Search(model);

                
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

        [HttpPost("MUSEUM_CREATE")]
        public async Task<APIResponse_Model> Museum_Create(Museum_model? model)
        {
            try
            {
                var results = await _museumService.Museum_Create(model);


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

        [HttpPost("MUSEUM_EDIT")]
        public async Task<APIResponse_Model> Museum_Edit(Museum_model? model)
        {
            try
            {
                var results = await _museumService.Museum_Edit(model);


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

        [HttpPost("MUSEUM_DELETE")]
        public async Task<APIResponse_Model> Museum_Delete(string MuseumId)
        {
            try
            {
                var results = await _museumService.Museum_Delete(MuseumId);


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

        [HttpPost("MUSEUM_GETBYID")]
        public async Task<APIResponse_Model> Museum_getbyId(string MuseumId)
        {
            try
            {
                var results = await _museumService.Museum_getbyId(MuseumId);


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
