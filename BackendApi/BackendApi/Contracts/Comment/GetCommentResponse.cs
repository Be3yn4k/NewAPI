namespace BackendApi.Contracts.Comment
{
    public class GetCommentResponse
    {
        public int book_id { get; set; }
        public int users_id { get; set; }
        public string comment_text { get; set; } = null!;
        public DateTime comment_date { get; set; }
        public int Created_by { get; set; }
        public DateTime Created_at { get; set; }
        public int Changed_by { get; set; }
        public DateTime Changed_at { get; set; }
        public int Deleted_by { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}
