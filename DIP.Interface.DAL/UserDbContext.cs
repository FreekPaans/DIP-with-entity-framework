using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DIP.Interface.DAL {
    class UserDbContext : DbContext{
        public DbSet<User> Users{get;set;}
    }
}
