namespace ProjektSemestralnyCSharp
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}
