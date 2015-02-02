using ITMApp.Controllers;
using ITMApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMApp.Tests
{
    [TestClass]
    public class TestITMApp
    {
        [TestMethod]
        public void CanFilterSwitches()
        {
            //Arrange
            List<_switch> Switches = new List<_switch>(){
               new _switch() {
                   Name = "S1",
                   switchID = 1,
                   status = new status[] {
                       new status() { statusID = 1, datetime = DateTime.Now, action = "+1"},
                   }},
               new _switch() {
                   Name = "S2",
                   switchID = 2,
                   status = new status[] {
                       new status() { statusID = 2, datetime = DateTime.Now.AddDays(1), action = "-1"},
                   }}
           };

            //arrange - new controller with mock object
            HomeController controller = new HomeController(Switches);
            controller.PageSize = 3;

            //Act
            Product[] result = ((ProductsListViewModel)controller.List("cat2", 1).Model).Products.ToArray();

            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "cat2");
        }
    }
}
