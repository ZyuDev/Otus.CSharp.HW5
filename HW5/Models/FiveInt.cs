using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Models
{
    public class FiveInt
    {
        private int _i1;
        private int _i2;
        private int _i3;
        private int _i4;
        private int _i5;

        public FiveInt Get()
        {
            return new FiveInt() { _i1 = 1, _i2 = 2, _i3 = 3, _i4 = 4, _i5 = 5 };
        }

        public override bool Equals(object obj)
        {
            return obj is FiveInt @int &&
                   _i1 == @int._i1 &&
                   _i2 == @int._i2 &&
                   _i3 == @int._i3 &&
                   _i4 == @int._i4 &&
                   _i5 == @int._i5;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_i1, _i2, _i3, _i4, _i5);
        }

        public FiveInt()
        {

        }

        public FiveInt(int i1, int i2, int i3, int i4, int i5)
        {
            _i1 = i1;
            _i2 = i2;
            _i3 = i3;
            _i4 = i4;
            _i5 = i5;
        }

        public override string ToString()
        {
            return $"{_i1}-{_i2}-{_i3}-{_i4}-{_i5}";
        }
    }
}
