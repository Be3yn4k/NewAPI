namespace BackendApi.Contracts.Book_status
{
    public class CreateBook_statusRequest
    {
        public string status_name { get; set; } = null!;
        public int Changed_by { get; set; }
        public DateTime Changed_at { get; set; }
    }
}
