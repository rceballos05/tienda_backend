namespace Tienda.Infrastructure.Commons.Bases.Requests
{
    public class BasePaginationRequest
    {
        public int NumPages { get; set; } = 1;
        public int NumRecordsPage { get; set; } = 10;
        private readonly int MaxNumRecords = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        public int Records
        {
            get => NumRecordsPage;
            set => NumRecordsPage = value > MaxNumRecords ? NumRecordsPage : value;
        }
    }
}
