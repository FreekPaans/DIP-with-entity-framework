using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Interface.DAL{
    public class PersistentUserDataAccess : UserDataAccess{
        readonly UserDbContext _dbContext;
        public PersistentUserDataAccess() {
            _dbContext = new UserDbContext();
        }

        public IUser GetUserById(int userId) {
            return _dbContext.Users.Single(_=>_.Id == userId);
        }

        public IUser GetUserByName(string name) {
            return _dbContext.Users.Single(_=>_.Name==name);
        }

        public void Save() {
            _dbContext.SaveChanges();
        }

        public IUser New() {
            var user = new User();

            _dbContext.Users.Add(user);

            return user;
        }

        //this method is for demonstration purposes only,normally you would find another way to reset the db between testruns
        public void Clear() {
            var users = _dbContext.Users.ToList();
            _dbContext.Users.RemoveRange(users);
            _dbContext.SaveChanges();
        }
    }
}
