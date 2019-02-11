using Microsoft.VisualStudio.TestTools.UnitTesting;
using rebulanyum.CatalogApp.Business;
using Moq;
using System.Linq;
using rebulanyum.CatalogApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace rebulanyum.CatalogApp.Test
{
    [TestClass]
    public class ProductBusinessTests
    {
        static Mock<CatalogAppContext> contextMock;
        [ClassInitialize]
        public static void InitializeProductBusinessTests(TestContext testContext)
        {
            contextMock = new Mock<CatalogAppContext>(MockBehavior.Loose);
        }
        ProductBusiness business;
        [TestInitialize]
        public void InitializeProductBusinessTest()
        {
            contextMock.Reset();
            business = new ProductBusiness(contextMock.Object);
        }
        [TestMethod]
        public void GetProducts_CanRetrieveProducts()
        {
            contextMock.SetupProperty(context => context.Product);

            business.GetProducts(true);

            contextMock.VerifyGet(context => context.Product);
        }

        [TestMethod]
        public async Task GetProductByIdAsync_ReturnsNullWhenIdDoesntExists()
        {
            var productSetMock = new Mock<DbSet<Product>>();
            productSetMock.Setup(set => set.FindAsync(123)).Returns(Task.FromResult<Product>(null));
            contextMock.SetupProperty(context => context.Product, productSetMock.Object);

            var result = await business.GetProductByIdAsync(123);

            productSetMock.Verify(set => set.FindAsync(123));
            Assert.IsNull(result);
        }
    }

    public class MockDbSet<T> : DbSet<T> where T : class
    {
    }
}
