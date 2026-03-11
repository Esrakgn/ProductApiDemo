using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApiDemo.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //null uyarısını azaltır 
        public decimal Price { get; set; }
    }

}
