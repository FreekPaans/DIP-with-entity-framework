using DIP.DataMapper.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DataMapper.DAL {
    public class PersistentUserDataAccess:UserDataAccess {
        readonly UserDbContext _context;
        readonly UserMapper _userMapper;
        public PersistentUserDataAccess() {
            _context = new UserDbContext();
            _userMapper = new UserMapper();
        }

        public void Clear() {
            _context.Users.RemoveRange(_context.Users.ToList());
            _context.SaveChanges();
        }

        public User GetUserById(UserId userId) {
            return _userMapper.Map(_context.Users.Find(userId.AsInt()));
        }

        public User GetUserByName(Username name) {
            var nameAsString = name.AsString(); //we cannot do name.AsString() in the LINQ query because EF can't translate that to SQL
            return _userMapper.Map(_context.Users.Single(_=>_.Name == nameAsString));
        }

        public void Save(User user) {
            if(user.Id.IsTemporary) {
                SaveNewUser(user);
                return;
            }
            SaveExistingUser(user);
        }

        private void SaveExistingUser(User user) {
            var userRecord = _context.Users.Find(user.Id.AsInt());

            _userMapper.MapTo(user,userRecord);
            _context.SaveChanges();
        }

        private void SaveNewUser(User user) {
            var userRecord = new UserRecord {};
            _userMapper.MapTo(user,userRecord);
            _context.Users.Add(userRecord);
            _context.SaveChanges();
            user.AssignId(UserId.FromInt(userRecord.Id));
        }
    }
}
