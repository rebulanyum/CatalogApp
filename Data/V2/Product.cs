using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace rebulanyum.CatalogApp.Data.V2
{ 
    /// <summary>
    /// The Product entity.
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Identity of the Product.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Code of the Product.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The Name of the Product.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Price of the Product.
        /// </summary>
        [Range(0, double.MaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = "{0} value must be greater than 0.")]
        public decimal Price { get; set; }
        /// <summary>
        /// The Last Update time of the Product.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
    
}
