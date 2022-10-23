using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalAndSales
{
    class Error:Exception
    {
        public Error(string s):base(s)
        {

        }
    }
}
