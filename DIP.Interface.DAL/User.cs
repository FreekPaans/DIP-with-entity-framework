﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DIP.Interface.DAL {
    class User : IUser{
        [Key]
        public int Id {get;set;}
        [Index(IsUnique=true)]
        [MaxLength(128)]
        [Required]
        public string Name {get;set;}
        public int Age{get;set;}  
    }
}
