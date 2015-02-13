using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP {
    public interface IUser {
        string Name { get; set; }

        int Id { get; set; }

        int Age{get;set;}
    }
}
