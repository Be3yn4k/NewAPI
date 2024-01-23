namespace BackendApi.Contracts.Rating
{
    public class CreateRatingRequest
    {
        public int book_id { get; set; }
        public int users_id { get; set; }
        public int number { get; set; }
        public int Created_by { get; set; }
        public DateTime Created_at { get; set; }
        public int Changed_by { get; set; }
        public DateTime Changed_at { get; set; }
        public int Deleted_by { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}
