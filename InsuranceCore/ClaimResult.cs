using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCore
{
    public class ClaimResult
    {
        public bool approved { get; set; }
        public decimal payout { get; set; }
        public string reasonCode { get; set; }
    }
}
