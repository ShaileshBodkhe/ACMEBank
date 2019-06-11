using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Entity
{
    public class Account : EntityBase
    {
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
    }
}
