using System;
using System.Collections.Generic;
using System.Text;

namespace SwissAddressResolver
{
    public class Street
    {
        public int Plz { get; set; }
        public string Municipality { get; set; }
        public string StreetName { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Plz, StreetName, Municipality);
        }
    }

}
