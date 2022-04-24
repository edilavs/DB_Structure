using System;
using System.Collections.Generic;
using System.Text;

namespace DBStructure.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutText { get; set; }
        public double Price  { get; set; }
        public double DiscountPercent { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        

    }
}
