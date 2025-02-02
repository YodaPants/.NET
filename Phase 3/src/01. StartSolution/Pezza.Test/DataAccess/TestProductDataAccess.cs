namespace Pezza.Test.DataAccess
{
    using System.Threading.Tasks;
    using Bogus;
    using NUnit.Framework;
    using Pezza.Common.DTO;
    using Pezza.DataAccess.Data;

    [TestFixture]
    public class TestProductDataAccess : QueryTestBase
    {
        private ProductDataAccess handler;

        private ProductDTO dto;

        [SetUp]
        public async Task Init()
        {
            this.handler = new ProductDataAccess(this.Context, Mapper());
            this.dto = ProductTestData.ProductDTO;
            this.dto = await this.handler.SaveAsync(this.dto);
        }

        [Test]
        public async Task GetAsync()
        {
            var response = await this.handler.GetAsync(this.dto.Id);

            Assert.IsTrue(response != null);
        }

        [Test]
        public async Task GetAllAsync()
        {
            var response = await this.handler.GetAllAsync();
            var outcome = response.Count;

            Assert.IsTrue(outcome == 1);
        }

        [Test]
        public void SaveAsync()
        {
            Assert.IsTrue(this.dto != null);
        }

        [Test]
        public async Task UpdateAsync()
        {
            this.dto.Name = new Faker().Commerce.Product();
            var response = await this.handler.UpdateAsync(this.dto);
            var outcome = response.Name.Equals(this.dto.Name);

            Assert.IsTrue(outcome);
        }

        [Test]
        public async Task DeleteAsync()
        {
            var response = await this.handler.DeleteAsync(this.dto.Id);

            Assert.IsTrue(response);
        }
    }
}
