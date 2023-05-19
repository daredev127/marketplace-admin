namespace DummySalesHistoryApi.Dtos
{
    public class SalesHistoryResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<SalesHistoryDto> Data { get; set; }
    }
}
