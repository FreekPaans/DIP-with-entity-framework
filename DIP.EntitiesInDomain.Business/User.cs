using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.EntitiesInDomain.Business {
    public class User {
        public int Age { get; set; }

        string _name;

        public string Name {
            get {
                return _name;
            }
            set {
                if(string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException("name");
                }
                _name = value;
            }
        }

        public int Id { get; set; }
    }
}
