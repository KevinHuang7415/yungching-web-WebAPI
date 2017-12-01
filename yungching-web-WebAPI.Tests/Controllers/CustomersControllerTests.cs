using Microsoft.VisualStudio.TestTools.UnitTesting;
using yungching_web_WebAPI.Tests.Repository;
using System.Web.Http.Results;
using yungching_web_WebAPI.Models;
using System.Net;

namespace yungching_web_WebAPI.Controllers.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void GetCustomersTest()
        {
            // 排列
            var (repo, controller) = Arrange();

            // 作用
            var result = controller.GetCustomers();

            // 判斷提示
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCustomerTest()
        {
            // 排列
            var (repo, controller) = Arrange();

            // 作用
            var value = controller.GetCustomer(TestData1.Id) as OkNegotiatedContentResult<Customer>;
            var result = value.Content;

            // 判斷提示
            Assert.AreEqual("Kevin", result.ContactName);
        }

        [TestMethod]
        public void PostCustomerTest()
        {
            // 排列
            var (repo, controller) = Arrange();

            // 作用
            var value = controller.PostCustomer(TestData2.Customer) as CreatedAtRouteNegotiatedContentResult<Customer>;
            var result = value.Content;

            // 判斷提示
            Assert.AreEqual("kevin", result.ContactName);
        }

        [TestMethod]
        public void PutCustomerTest()
        {
            // 排列
            var (repo, controller) = Arrange();

            // 作用
            var customer = repo.Read(data => data.CustomerID == TestData1.Id);
            customer.City = "taoyuan";
            var result = controller.PutCustomer(TestData1.Id, customer) as StatusCodeResult;

            // 判斷提示
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            // 排列
            var (repo, controller) = Arrange();

            // 作用
            var value = controller.DeleteCustomer(TestData1.Id) as OkNegotiatedContentResult<Customer>;
            var result = value.Content;

            // 判斷提示
            Assert.AreEqual("Kevin", result.ContactName);
        }

        private (FakeRepository, CustomersController) Arrange()
        {
            var repo = new FakeRepository();
            var controller = new CustomersController(repo);
            return (repo, controller);
        }
    }
}