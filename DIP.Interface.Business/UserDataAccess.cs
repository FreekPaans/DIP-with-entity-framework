using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP {
    public interface UserDataAccess {
        IUser GetUserById(int userId);
        IUser GetUserByName(string name);
        void Save();
        IUser New();
    }
}
