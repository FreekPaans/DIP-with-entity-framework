using DIP.EntitiesInDomain.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;

namespace DIP.EntitiesInDomain.DAL {
    class UserDbContext : DbContext{
        public DbSet<User> Users{get;set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(_=>_.Id)
                .Property(_=>_.Name)
                    .HasMaxLength(128)
                    .IsRequired()
                    .HasColumnAnnotation("Index",   
                        new IndexAnnotation(
                            new IndexAttribute() { 
                            IsUnique = true 
                    }));
            
        }
    }
}
