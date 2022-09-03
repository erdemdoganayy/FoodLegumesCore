﻿namespace CoreAndFood.Data.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
