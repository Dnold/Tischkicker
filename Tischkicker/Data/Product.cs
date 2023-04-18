namespace Tischkicker.Data
{
    public class Product
    {
        public int id { get; set; }
        public float price { get; set; }
        public  string name { get; set; }
        public string description { get; set; }
        public string[] picUrls { get; set; }
        public int categoryId { get; set; }
        public List<Rating> ratings { get; set; }
    }
}
