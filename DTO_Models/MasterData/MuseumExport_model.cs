using DTO_Models.Response;

namespace DTO_Models.MasterData
{
    public class MuseumExport_model
    {
        public Museum_model? searchParams { get; set; }

        public Export_model? exportParams { get; set; }
    }
}
