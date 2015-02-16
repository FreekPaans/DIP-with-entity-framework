using DIP.DataMapper.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DIP.DataMapper.DAL {
    class UserDbContext : DbContext{
        public DbSet<UserRecord> Users {get;set;}
    }
}
