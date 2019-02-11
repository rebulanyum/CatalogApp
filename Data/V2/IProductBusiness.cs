using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

namespace rebulanyum.CatalogApp.Data.V2
{
    /// <summary>
    /// The interface for Product related operations.
    /// </summary>
    public interface IProductBusiness
    {
        /// <summary>
        /// Retrieve Products from the underlying store.
        /// </summary>
        /// <returns>Returns the Products.</returns>
        IEnumerable<Product> GetProducts();
        /// <summary>
        /// Retrieve the Product with the specified <paramref name="id"/> value from the underlying store.
        /// </summary>
        /// <param name="id">The Id of the Product.</param>
        /// <returns>Returns the Product with the given id.</returns>
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// Saves the Product to the store.
        /// </summary>
        /// <param name="product">The Product instance to be saved.</param>
        /// <returns></returns>
        Task SaveProductAsync(Product product);
        /// <summary>
        /// Creates the Product in the store.
        /// </summary>
        /// <param name="product">The Product instance to be created in the store.</param>
        /// <returns></returns>
        Task CreateProductAsync(Product product);
        /// <summary>
        /// Deletes the Product that has the specified Id.
        /// </summary>
        /// <param name="id">The Id of the Product.</param>
        /// <returns>The deleted Product.</returns>
        Task<Product> DeleteProductByIdAsync(int id);
        /// <summary>
        /// Checks if any Product with the given Id exists in the store.
        /// </summary>
        /// <param name="id">The Id of the Product.</param>
        /// <returns>Returns True if the Product exists; otherwisse, returns False.</returns>
        Task<bool> ProductExistsByIdAsync(int id);
    }
    
}
