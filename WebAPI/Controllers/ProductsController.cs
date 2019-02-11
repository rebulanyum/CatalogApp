using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using rebulanyum.CatalogApp.Business;
using rebulanyum.CatalogApp.Data;

namespace WebAPI.Controllers
{
    /// <summary>
    /// The API of Products.
    /// </summary>
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        IProductBusiness productBusiness;
        public ProductsController(IProductBusiness productBusiness) : base()
        {
            this.productBusiness = productBusiness;
        }

        // GET: api/Products
        /// <summary>
        /// Retrieve Products from the underlying store.
        /// </summary>
        /// <returns>Returns the Products.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product[]))]
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return productBusiness.GetProducts(false);
        }

        // GET: api/Products/5
        /// <summary>
        /// Retrieve the Product with the specified <paramref name="id"/> value.
        /// </summary>
        /// <param name="id">The Id of the Product.</param>
        /// <returns>Returns the Product with the given id.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await productBusiness.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        /// <summary>
        /// Updates the Product with the specified <paramref name="id"/> value.
        /// </summary>
        /// <param name="id">The Id of Product.</param>
        /// <param name="product">The Product values to be updated.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                await productBusiness.SaveProductAsync(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await productBusiness.ProductExistsByIdAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        /// <summary>
        /// Creates the Product with the given <paramref name="product"/> values.
        /// </summary>
        /// <param name="product">The product that will be created.</param>
        /// <returns>Returns created Product.</returns>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await productBusiness.CreateProductAsync(product);
            }
            catch (DbUpdateException)
            {
                if (await productBusiness.ProductExistsByIdAsync(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        /// <summary>
        /// Deletes the Product with the specified <paramref name="id"/> value.
        /// </summary>
        /// <param name="id">The Id of the Product.</param>
        /// <returns>Returns the created Product.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await productBusiness.DeleteProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Retrieves the Products in Excel file format.
        /// </summary>
        /// <returns>Returns the Products in Excel file format.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [HttpGet("[action]")]
        public FileStreamResult Export()
        {
            var products = GetProducts();
            var stream = new System.IO.MemoryStream();
            using (var excel = new OfficeOpenXml.ExcelPackage(stream))
            {
                var excelWorksheet = excel.Workbook.Worksheets.Add("CatalogApp-Products");
                excelWorksheet.Cells.LoadFromCollection(products, true);
                excel.Save();
                stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CatalogApp-Products.xlsx");
            }
        }
    }
}