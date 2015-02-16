using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP {
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
			AssertValidUsername(newName);
            var user = _dataAccess.GetUserById(userId);
            user.Name = newName;
            _dataAccess.Save();
        }

        public int AddUser(string withUsername, int withAge) {
			AssertValidUsername(withUsername);

            var user = _dataAccess.New();
            user.Age = withAge;
            user.Name = withUsername;
            _dataAccess.Save();

            return user.Id;
        }

		private static void AssertValidUsername(string withUsername) {
			if(string.IsNullOrWhiteSpace(withUsername)) {
				throw new ArgumentNullException("name");
			}
		}
    }
}
