using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Entity
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsMarried { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }

        //Lazy loaded and loaded only if the specific customer details are requested
        public IEnumerable<Account> Accounts { get; set; }
    }
}
