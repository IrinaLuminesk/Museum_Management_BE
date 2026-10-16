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

        [HttpPost("Search")]
        public async Task<APIResponse_Model> Search(Museum_model? model)
        {
            try
            {
                var results = await _museumService.Search(model);

                
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
