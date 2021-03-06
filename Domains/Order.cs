﻿using System;

namespace ProjektSemestralnyCSharp
{
    //Representation of Orders table in Database
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderPickUp { get; set; }
        public DateTime OrderReturn { get; set; }
        public virtual Client Client { get; set; }
        public Product Product{ get; set; }
    }
}
