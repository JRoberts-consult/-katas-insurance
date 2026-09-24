using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCore
{
    public class Policy
    {
        public string policyId { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public decimal deductible { get; set; }
        public decimal coverageLimit { get; set; }
        public List<string> coveredIncidents { get; set; }

        public Policy(string policyId, DateTimeOffset startDate, DateTimeOffset endDate, decimal deductible, decimal coverageLimit, List<string> coveredIncidents)
        {
            this.policyId = policyId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.deductible = deductible;
            this.coverageLimit = coverageLimit;
            this.coveredIncidents = coveredIncidents;

        }
    }
}
