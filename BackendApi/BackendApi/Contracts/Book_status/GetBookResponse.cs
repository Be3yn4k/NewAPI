namespace BackendApi.Contracts.Book_status
{
    public class GetBook_statusResponse
    {
        public string status_name { get; set; } = null!;
        public int Changed_by { get; set; }
        public DateTime Changed_at { get; set; }
    }
}
