using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DataMapper.Business {
    public interface UserDataAccess {
        User GetUserById(UserId userId);

        User GetUserByName(Username name);

        void Save(User user);
    }
}
