using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ITMApp.DBContext;
using ITMApp.Models;
using ITMApp.Controllers;
using System.Linq;

namespace ITMApp.Tests
{
    [TestClass]
    public class Test
    { 
        [TestMethod]
        public void CanFilterCommurators()
        {
            //Arrange
            Mock<IDBRepository> mock = new Mock<IDBRepository>();
            mock.Setup(h => h.switches).Returns(new _switch[] {
                new _switch { Name = "S1", status = new status[] { new status { action = "+1" }}},
                new _switch { Name = "S2", status = new status[] { new status { action = "-1" }}},
            });

            HomeController controller = new HomeController(mock.Object);

            //Act
            IOrderedEnumerable<status> result = (IOrderedEnumerable<status>)controller.Index("S1").Model;

            // Assert
            Assert.AreEqual(result.Count(), 1);
            Assert.IsTrue(result.First().action == "+1");
        }




    }
}
