using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIP.Interface.DAL;
using System.Data.Entity.Infrastructure;

namespace DIP.Interface.Tests {
    [TestClass]
    public class UserTests {
        UserApplicationService _appService;
        PersistentUserDataAccess _dataAccess;

        [TestInitialize]
        public void Init() {    
            new PersistentUserDataAccess().Clear();
            ResetStorage();
        }

        private void ResetStorage() {
            _dataAccess=  new PersistentUserDataAccess();
            _appService = new UserApplicationService(_dataAccess);
        }
        
        [TestMethod]
        public void test_add_user() {
            var userId = _appService.AddUser("freek", 30);

            var user = _dataAccess.GetUserById(userId);

            Assert.AreEqual("freek", user.Name);
            Assert.AreEqual(30,user.Age);
        }

        [TestMethod]
        public void test_change_username() {
            var userId = _appService.AddUser("freek", 30);
            
            _appService.ChangeUsername(userId,"freekpaans"); 

            ResetStorage();

            var user = _dataAccess.GetUserById(userId);

            Assert.AreEqual("freekpaans", user.Name);
        }

        [TestMethod]
        public void test_find_user_id() {
            var userId = _appService.AddUser("freek", 30);
            
            ResetStorage();

            var foundUserId = _appService.GetUserId("freek");

            Assert.AreEqual(userId,foundUserId);
        }
        
        [TestMethod]
        public void test_username_unique() {
            _appService.AddUser("freek", 30);
            ResetStorage();
        
            try {
                _appService.AddUser("freek", 30);
            }
            catch(DbUpdateException e) {
                return;
            }

            Assert.Fail("Adding user with existing username doesn't fail");
        }

        [TestMethod]
        public void test_username_notempty() {
            try {
                _appService.AddUser("", 30);
            
            }
            catch(ArgumentNullException e) {
                return;
            }

            Assert.Fail("addign user with empty name didn't fail");
        }
    }
}
