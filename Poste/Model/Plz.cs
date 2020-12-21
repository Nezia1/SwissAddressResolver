using System;
using System.Collections.Generic;
using System.Text;

namespace SwissAddressResolver
{
    public class Plz
    {
        public int Number { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }

}
