using DIP.DataMapper.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.DataMapper.DAL {
    class UserMapper {
        internal Business.User Map(UserRecord userRecord) {
            return User.Existing(
                UserId.FromInt(userRecord.Id),
                Username.FromString(userRecord.Name),
                Age.FromInt(userRecord.Age)
            );
        }

        
        internal void MapTo(User user,UserRecord userRecord) {
            userRecord.Age = user.Age.AsInt();
            userRecord.Name = user.Name.AsString();
        }
    }
}
