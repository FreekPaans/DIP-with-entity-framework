using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIP.DataMapper.Business;
using DIP.DataMapper.DAL;
using System.Data.Entity.Infrastructure;

namespace DIP.DataMapper.Tests {
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
            var userId = AddUser("freek", 30);

            var user = _dataAccess.GetUserById(userId);

            AssertAreEqualUsername("freek", user.Name);
            AssertAreEqualAge(30,user.Age);
        }

        [TestMethod]
        public void test_change_username() {
            var userId = AddUser("freek", 30);
            
            ChangeUsername(userId,"freekpaans"); 

            ResetStorage();

            var user = _dataAccess.GetUserById(userId);

            AssertAreEqualUsername("freekpaans", user.Name);
        }

       

        [TestMethod]
        public void test_find_user_id() {
            var userId = AddUser("freek", 30);
            
            ResetStorage();

            var foundUserId = GetUserId("freek");

            AssertAreEqualUserId(userId,foundUserId);
        }
             

        [TestMethod]
        public void test_username_unique() {
            AddUser("freek", 30);
            ResetStorage();
        
            try {
                AddUser("freek", 30);
            }
            catch(DbUpdateException e) {
                return;
            }

            Assert.Fail("Adding user with existing username doesn't fail");
        }

        private void AssertAreEqualAge(int expected,Age age) {
            Assert.AreEqual(Age.FromInt(expected), age);
        }

        private void AssertAreEqualUsername(string expectedUsername,Username username) {
            Assert.AreEqual(Username.FromString(expectedUsername), username);
        }

        private void AssertAreEqualUserId(UserId userId,UserId foundUserId) {
            Assert.AreEqual(userId,foundUserId);
        }

        
        private UserId AddUser(string username,int age) {
            return _appService.AddUser(Username.FromString(username), Age.FromInt(age));
        }

        private void ChangeUsername(UserId userId,string newUsername) {
            _appService.ChangeUsername(userId, Username.FromString(newUsername));
        }

        private UserId GetUserId(string username) {
            return _appService.GetUserId(Username.FromString(username));
        }
    }
}
