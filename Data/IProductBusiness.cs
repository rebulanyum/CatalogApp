using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

namespace rebulanyum.CatalogApp.Data
{ 
    public interface IProductBusiness
    {
        IEnumerable<Product> GetProducts(bool includePhoto = false);

        Task<Product> GetProductByIdAsync(int id);

        Task SaveProductAsync(Product product);

        Task CreateProductAsync(Product product);

        Task<Product> DeleteProductByIdAsync(int id);

        Task<bool> ProductExistsByIdAsync(int id);
    }
    
}
