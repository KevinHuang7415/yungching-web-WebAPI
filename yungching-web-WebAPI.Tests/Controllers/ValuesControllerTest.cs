using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yungching_web_WebAPI.Controllers;

namespace yungching_web_WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            var controller = new ValuesController();

            // 作用
            var result = controller.Get();

            // 判斷提示
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // 排列
            var controller = new ValuesController();

            // 作用
            var value = controller.Get(1) as OkNegotiatedContentResult<string>;
            var result = value.Content;

            // 判斷提示
            Assert.AreEqual("value2", result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            var controller = new ValuesController();
            int count = controller.Get().Count();

            // 作用
            controller.Post("value");

            // 判斷提示
            Assert.AreEqual(count + 1, controller.Get().Count());
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            var controller = new ValuesController();

            // 作用
            var result = controller.Put(1, "value");

            // 判斷提示
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Delete()
        {
            // 排列
            var controller = new ValuesController();
            int count = controller.Get().Count();

            // 作用
            var result = controller.Delete(1);

            // 判斷提示
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(count - 1, controller.Get().Count());
        }
    }
}