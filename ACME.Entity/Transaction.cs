﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Entity
{
    public class Transaction : EntityBase
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
