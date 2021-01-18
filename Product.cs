﻿namespace ProjektSemestralnyCSharp
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}
