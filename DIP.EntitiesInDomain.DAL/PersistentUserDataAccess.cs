using DIP.EntitiesInDomain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.EntitiesInDomain.DAL {
public class PersistentUserDataAccess : UserDataAccess{
    readonly UserDbContext _context;
    public PersistentUserDataAccess() {
        _context = new UserDbContext();
    }
        
    public User GetUserById(int userId) {
        return _context.Users.Find(userId);
    }

    public User GetUserByName(string name) {
        return _context.Users.Single(_=>_.Name  == name);
    }

    public void Save() {
        _context.SaveChanges();
    }

    public void Clear() {
        _context.Users.RemoveRange(_context.Users.ToList());
        _context.SaveChanges();
    }


    public void AddNewUser(User user) {
        _context.Users.Add(user);
    }
}
}
