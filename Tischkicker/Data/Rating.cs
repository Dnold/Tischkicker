namespace Tischkicker.Data
{
    public class Rating
    {
        public int ratingId { get; set; }
        public int productId { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public int stars { get; set; }

    }
}
