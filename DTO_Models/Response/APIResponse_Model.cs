namespace DTO_Models.Response
{
    public class APIResponse_Model
    {
        public int responseCode { get; set; }

        public string? responseMessage { get; set; }
        public object? result { get; set; }


    }
}
