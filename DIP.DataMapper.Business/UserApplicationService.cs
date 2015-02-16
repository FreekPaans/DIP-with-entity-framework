using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DataMapper.Business {
    public class UserApplicationService {
        readonly UserDataAccess _dataAccess;

        public UserApplicationService(UserDataAccess dataAccess) {
            _dataAccess=dataAccess;
        }
        public Username GetUserName(UserId userId) {
            return _dataAccess.GetUserById(userId).Name;
        }

        public UserId GetUserId(Username name) {
            return _dataAccess.GetUserByName(name).Id;
        }

        public void ChangeUsername(UserId userId, Username newName) {
            var user = _dataAccess.GetUserById(userId);

            user.ChangeUsername(newName);

            _dataAccess.Save(user);
        }

        public UserId AddUser(Username withUsername, Age withAge) {
            var user = User.New(withUsername, withAge);
            
            _dataAccess.Save(user);

            return user.Id;
        }
    }
}
