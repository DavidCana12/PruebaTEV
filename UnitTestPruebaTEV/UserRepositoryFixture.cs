using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaTEV.Class;
using PruebaTEV.Core;
using PruebaTEV.Implementation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnitTestPruebaTEV
{
    [TestClass]
    public class UserManagerTests
    {
        private Mock<IUserRepository> _userManagerMock;

        public UserManagerTests()
        {
            Thread.CurrentThread.CurrentCulture
                = Thread.CurrentThread.CurrentUICulture
                = CultureInfo.GetCultureInfo("en-US");

            _userManagerMock = new Mock<IUserRepository>();
        }

        [TestMethod]
        public void RegisterUser_Succeed()
        {
            //Arrange
            var userManager = new UserManager(_userManagerMock.Object);
            var User1 = ValidUser();


            //Act
            userManager.Add(User1);

            //Assert
            Assert.AreNotEqual(null, User1.id);
            _userManagerMock.Verify(x => x.CreateUser(User1));
        }

        [TestMethod]
        public void UpdatedUser_Succeed()
        {
            //Arrange
            var user1 = ValidUser();
            _userManagerMock.Setup(x => x.GetUserId(user1.id))
                .Returns(user1);

            var userManager = new UserManager(_userManagerMock.Object);

            //Act
            userManager.Update(user1);

            //Assert
            _userManagerMock.Verify(x => x.UpdateUser(user1), Times.Never());
        }

        [TestMethod]
        public void AllUser()
        {
            //Arrange

            var insertedEntries = new List<User>();
            var userList = new User[] { ValidUser(), ValidUser2(), ValidUser3() };

            _userManagerMock.Setup(x => x.CreateUser(ValidUser()))
                .Callback<User>(e => insertedEntries.Add(e));
            _userManagerMock.Setup(x => x.CreateUser(ValidUser2()))
                .Callback<User>(e => insertedEntries.Add(e));
            _userManagerMock.Setup(x => x.CreateUser(ValidUser3()))
                .Callback<User>(e => insertedEntries.Add(e));

            _userManagerMock.Setup(x => x.GetUser())
                .Returns((IEnumerable<User>)userList);


            var userManager = new UserManager(_userManagerMock.Object);

            //Act
            var result = userManager.GetList();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetUser()
        {
            //Arrange

            var insertedEntries = new List<User>();
            var user = ValidUser2();

            _userManagerMock.Setup(x => x.CreateUser(user))
                .Callback<User>(e => insertedEntries.Add(e));

            _userManagerMock.Setup(x => x.GetUserId(2))
                .Returns((User)user);


            var userManager = new UserManager(_userManagerMock.Object);

            //Act
            var result = userManager.GetById(2);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);

        }

        [TestMethod]
        public void Deleted()
        {
            //Arrange

            var user = ValidUser2();

            _userManagerMock.Setup(x => x.GetUserId(user.id))
                 .Returns((User)user);

            var userManager = new UserManager(_userManagerMock.Object);

            //Act
            userManager.Delete(user.id);

            //Assert
            _userManagerMock.Verify(x => x.UpdateUser(user), Times.Never());
        }

        private User ValidUser() => new User()
        {
            Address = "Test Address",
            Name = "Test Name",
            LastName = "Test Last Name",
            id = 1
        };

        private User ValidUser2() => new User()
        {
            Address = "Test Address 2",
            Name = "Test Name 2",
            LastName = "Test Last Name 2",
            id = 2
        };

        private User ValidUser3() => new User()
        {
            Address = "Test Address 3",
            Name = "Test Name 3",
            LastName = "Test Last Name 3",

        };
    }
}
