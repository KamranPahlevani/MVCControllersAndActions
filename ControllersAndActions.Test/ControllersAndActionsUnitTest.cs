using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllersAndActions.Controllers;
using System.Web.Mvc;

namespace ControllersAndActions.Test
{
    [TestClass]
    public class ControllersAndActionsUnitTest
    {
        [TestMethod]
        public void Action_Index_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.Index();

            //Assert - check the result
            Assert.AreEqual("HomePage", result.ViewName);
        }

        [TestMethod]
        public void Action_ActionNameEqualViewName_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.ActionNameEqualViewName();

            //Assert - check the result
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Action_TransferDataByViewDataModel_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.TransferDataByViewDataModel();

            //Assert - check the result
            Assert.AreEqual("Hello World", result.ViewData.Model);
        }

        [TestMethod]
        public void Action_TransferDataByViewBag_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.TransferDataByViewBag();

            //Assert - check the result
            Assert.AreEqual("Hello", result.ViewBag.Message);
        }

        [TestMethod]
        public void Action_TransferDataByViewData_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.TransferDataByViewBag();

            //Assert - check the result
            Assert.AreEqual("Hello", result.ViewData["Message"]);
        }

        [TestMethod]
        public void Action_Redirect_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            RedirectResult result = target.Redirect();

            //Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void Action_RedirectToRoute_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            RedirectToRouteResult result = target.RedirectToRoute();

            //Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["ID"]);
        }

        [TestMethod]
        public void Action_RedirectToAction_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            RedirectToRouteResult result = target.RedirectToAction();

            //Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Action_TextContent_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ContentResult result = target.TextContent();

            //Assert - check the result
            Assert.AreEqual("text/plain", result.ContentType);
            Assert.AreEqual("this is plain text", result.Content);
        }

        [TestMethod]
        public void Action_TransferFileByName_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            FileResult result = target.TransferFileByName();

            //Assert - check the result
            Assert.AreEqual(@"~\Files\p5pl2e_en.pdf", ((FilePathResult)result).FileName);
            Assert.AreEqual("application/pdf", result.ContentType);
            Assert.AreEqual("cpuMpdel.pdf", result.FileDownloadName);
        }

        [TestMethod]
        public void Action_StatusCode_Test()
        {
            //Arrange - create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            HttpStatusCodeResult result = target.StatusCode();

            //Assert - check the result
            Assert.AreEqual(404, result.StatusCode);
        }


    }
}
