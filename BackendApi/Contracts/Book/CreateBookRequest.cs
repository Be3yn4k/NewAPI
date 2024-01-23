namespace BackendApi.Contracts.Book
{
    public class CreateBookRequest
    {
        public int genre_id { get; set; }
        public int book_status_id { get; set; }
        public string title { get; set; } = null!;
        public string author { get; set; } = null!;
        public DateOnly publication_date { get; set; }
        public int Created_by { get; set; }
        public DateTime Created_at { get; set; }
        public int Changed_by { get; set; }
        public DateTime Changed_at { get; set; }
        public int Deleted_by { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}