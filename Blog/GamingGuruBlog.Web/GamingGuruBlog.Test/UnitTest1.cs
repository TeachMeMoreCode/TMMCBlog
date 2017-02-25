using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamingGuruBlog.Web.Controllers;
using System.Web.Mvc;
using GamingGuruBlog.Domain.Models;

namespace GamingGuruBlog.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CategoryController_AddCategory_ReturnsNonNullViewResult()
        {
            //Arrange
            var mockCategoryRepository = new MockCategoryRepository();

            var controller = new CategoryController(mockCategoryRepository);
            //Act
            var result = controller.AddCategory() as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CategoryController_AddCategory_ChecksForInvalidModel()
        {
            //Arrange
            var mockCategoryRepository = new MockCategoryRepository();

            var controller = new CategoryController(mockCategoryRepository);
            var model = new Category();
            //Act
            var result = controller.AddCategory(model) as ViewResult;
            //Assert

            
            //result.ViewName = "ErrorView";
        }
        [TestMethod]
        public void CategoryController_DeleteCategory_ReturnsNonNullRedirectToAction()
        {
            //Arrange
            var mockCategoryRepository = new MockCategoryRepository();
            int id = 1;
            var controller = new CategoryController(mockCategoryRepository);
            //Act
            var result = controller.DeleteCategory(id) as RedirectToRouteResult;
            //Assert
            Assert.IsNotNull(result);

        }

    }
}

