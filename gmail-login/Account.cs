using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sun_bm
{
    class Account
    {
        public string user { get; set; }
        public string pass { get; set; }

        public string emailRecover { get; set; }
        public Account(string u, String p, String r)
        {
            this.user = u;
            this.pass = p; 
            this.emailRecover = r;
        }

    }
}
