namespace Marketplace.Admin.Application.Dtos
{
    public class ResponseBaseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
