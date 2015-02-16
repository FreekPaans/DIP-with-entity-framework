using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.EntitiesInDomain.Business {
    public interface UserDataAccess {
        User GetUserById(int userId);
        User GetUserByName(string name);
        void Save();

        void AddNewUser(User user);
    }
}
