using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace rebulanyum.CatalogApp.Data
{ 
    public partial class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        [Range(0, double.MaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = "{0} value must be greater than 0.")]
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
    
}
