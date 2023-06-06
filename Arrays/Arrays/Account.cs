using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Account
    {
        public int agency_id { get; }
        public string number_account { get; set; }

        public Account(int agency, string number) {

            agency_id =  agency; 
            number_account = number;
        }
    }
}
