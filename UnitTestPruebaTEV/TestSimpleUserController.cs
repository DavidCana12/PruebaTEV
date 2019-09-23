using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaTEV.Class;
using PruebaTEV.Controllers;
using PruebaTEV.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestPruebaTEV
{
    [TestClass]
    public class TestSimpleUserController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {



        }


        private User ConstructValidUser() => new User()
        {
            Address = "Test Address",
            Name = "Test Name",
            LastName = "Test Last Name",
        };

        private List<User> GetTestSessions()
        {
            var sessions = new List<User>();
            sessions.Add(new User()
            {
                Address = "Test Address",
                Name = "Test Name",
                LastName = "Test Last Name",
            });
            sessions.Add(new User()
            {
                Address = "Test Address 2",
                Name = "Test Name 2",
                LastName = "Test Last Name 2",
            });
            return sessions;
        }
    }
}
