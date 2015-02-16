using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.EntitiesInDomain.Business {
    public class UserApplicationService {
        readonly UserDataAccess _dataAccess;

        public UserApplicationService(UserDataAccess dataAccess) {
            _dataAccess=dataAccess;
        }
        public string GetUserName(int userId) {
            return _dataAccess.GetUserById(userId).Name;
        }

        public int GetUserId(string name) {
            return _dataAccess.GetUserByName(name).Id;
        }

        public void ChangeUsername(int userId, string newName) {
            var user = _dataAccess.GetUserById(userId);
            user.Name = newName;
            _dataAccess.Save();
        }

        public int AddUser(string withUsername, int withAge) {
            var user = new User {
                Age = withAge,
                Name = withUsername
            };
            _dataAccess.AddNewUser(user);

            _dataAccess.Save();

            return user.Id;
        }
    }
}
