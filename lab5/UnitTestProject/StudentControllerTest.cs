using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http.Headers;
using lab5.Models;
using System.Linq;
using lab5.Controllers;
using System.Web.Http.Results;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class StudentControllerTest : TestDbSet<Student>
    {
        [TestMethod]
        public void PostStudent_ShouldReturnSameProduct()
        {
            var controller = new StudentsController(new TestStudentsAppContext());

            var item = GetDemoProduct();

            var result =
                controller.PostStudent(item) as CreatedAtRouteNegotiatedContentResult<Student>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void PutStudent_ShouldReturnStatusCode()
        {
            var controller = new StudentsController(new TestStudentsAppContext());

            var item = GetDemoProduct();

            var result = controller.PutStudent(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutStudent_ShouldFail_WhenDifferentID()
        {
            var controller = new StudentsController(new TestStudentsAppContext());

            var badresult = controller.PutStudent(999, GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetStudent_ShouldReturnProductWithSameID()
        {
            var context = new TestStudentsAppContext();
            context.Students.Add(GetDemoProduct());

            var controller = new StudentsController(context);
            var result = controller.GetStudent(3) as OkNegotiatedContentResult<Student>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetStudents_ShouldReturnAllProducts()
        {
            var context = new TestStudentsAppContext();
            context.Students.Add(new Student { Id = 1, Name = "Name1", Surname = "Surname1", Faculty = "F1"});
            context.Students.Add(new Student { Id = 2, Name = "Name2", Surname = "Surname2", Faculty = "F2" });
            context.Students.Add(new Student { Id = 3, Name = "Name3", Surname = "Surname3", Faculty = "F3" });

            var controller = new StudentsController(context);
            var result = controller.GetStudents() as DbSetStudentsTest;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteStudent_ShouldReturnOK()
        {
            var context = new TestStudentsAppContext();
            var item = GetDemoProduct();
            context.Students.Add(item);

            var controller = new StudentsController(context);
            var result = controller.DeleteStudent(3) as OkNegotiatedContentResult<Student>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Student GetDemoProduct()
        {
            return new Student() { Id = 3, Name = "Name3", Surname = "Surname3", Faculty = "F3" };
        }
    }
}
