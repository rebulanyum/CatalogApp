using rebulanyum.CatalogApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace rebulanyum.CatalogApp.Business.Models
{
    public class ProductSummary
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }

        public ProductSummary(int id, string code, string name, decimal price, DateTime lastUpdated)
        {
            Id = id;
            Code = code;
            Name = name;
            Price = price;
            LastUpdated = lastUpdated;
        }

        public static implicit operator Product(ProductSummary model)
        {
            if (model == null)
                return null;

            var p = new Product()
            {
                Code = model.Code,
                Id = model.Id,
                LastUpdated = model.LastUpdated,
                Name = model.Name,
                Price = model.Price
            };
            return p;
        }
        public static implicit operator ProductSummary(Product model)
        {
            if (model == null)
                return null;

            var p = new ProductSummary(model.Id, model.Code, model.Name, model.Price, model.LastUpdated);
            return p;
        }
    }
    
}
