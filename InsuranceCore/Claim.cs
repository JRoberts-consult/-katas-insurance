using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCore
{
    public class Claim
    {
        public Claim(string policyId, string incidentType, DateTimeOffset incidentDate, decimal amountClaimed)
        {
            this.policyId = policyId;
            this.incidentType = incidentType;
            this.incidentDate = incidentDate;
            this.amountClaimed = amountClaimed;
        }
        public string policyId { get; set; }
        public string incidentType { get; set; }
        public DateTimeOffset incidentDate { get; set; }
        public decimal amountClaimed { get; set; }
    }
}
