using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using rebulanyum.CatalogApp.Data;

namespace rebulanyum.CatalogApp.Business
{
    public class ProductBusiness : CatalogAppBusinessBase, IProductBusiness
    {
        public ProductBusiness(CatalogAppContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProducts(bool includePhoto = false)
        {
            if (includePhoto)
            {
                return Context.Product;
            }

            return Context.Product.Select(product => new Product()
            {
                Code = product.Code,
                Id = product.Id,
                LastUpdated = product.LastUpdated,
                Name = product.Name,
                Price = product.Price
            });
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            var product = Context.Product.FindAsync(id);
            return product;
        }

        public Task SaveProductAsync(Product product)
        {
            Context.Entry(product).State = EntityState.Modified;

            return Context.SaveChangesAsync();
        }

        public Task CreateProductAsync(Product product)
        {
            Context.Product.Add(product);

            return Context.SaveChangesAsync();
        }

        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            var product = await Context.Product.FindAsync(id);
            if (product != null)
            {
                Context.Product.Remove(product);

                await Context.SaveChangesAsync();
            }
            return product;
        }

        public Task<bool> ProductExistsByIdAsync(int id)
        {
            return Context.Product.AnyAsync(e => e.Id == id);
        }
    }
}
