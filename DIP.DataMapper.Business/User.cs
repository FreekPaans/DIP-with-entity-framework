using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.DataMapper.Business {
    public class User {
        public Username Name { get; private set; }
        public UserId Id { get; private set; }
        public Age Age { get; private set; }

        public User(){}

        public void ChangeUsername(Username newName) {
            Name = newName;
        }

        internal static User New(Username withUsername,Age withAge) {
            return new User {
                Age = withAge,
                Name = withUsername,
                Id = UserId.NewUserId
            };
        }

        public static User Existing(UserId userId,Username username,Age age) {
            return new User() {
                Id = userId,
                Name = username,
                Age = age
            };
        }

        public void AssignId(UserId id) {
            if(!Id.IsTemporary) {
                throw new InvalidOperationException("Id already assigned");
            }

            Id = id;
        }

        public bool IsNew {
            get {
                return Id.IsTemporary;
            }
        }
    }
}
