using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP.DataMapper.Business {
    public struct Age {
        readonly int _intValue;

        Age(int intVal) {
            _intValue = intVal;
        }
        public static Age FromInt(int intVal) {
            return new Age(intVal);
        }

        public int AsInt() {
            return _intValue;
        }
    }
}
