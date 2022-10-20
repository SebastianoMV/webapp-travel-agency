﻿using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Days { get; set; }

        public Package()
        {

        }

        public Package(int id, string name, string description, decimal price, int days)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Days = days;
        }
    }
}
