using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.DataMapper.Business {
    public struct UserId {
        public readonly static UserId NewUserId = new UserId(default(int));
        readonly int _id;
        
        
        UserId(int id) {
            _id = id;
        }

        public int AsInt() {
            return _id;
        }

        public static UserId FromInt(int p) {
            return new UserId(p);
        }

        public bool IsTemporary {
            get {
                return this.Equals(NewUserId);
            }
        }
    }
}
