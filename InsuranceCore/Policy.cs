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

        public ClaimResult processClaim(Claim claim)
        {
            ClaimResult result = new ClaimResult();  // thinking we may build this incrimentally
            if (claim.incidentDate < startDate || claim.incidentDate > endDate)
            {
                result.approved = false;
                result.payout = 0;
                result.reasonCode = "POLICY_INACTIVE";
                return result;
            }
            if (!coveredIncidents.Any(incidentType => incidentType == claim.incidentType))// would probably toupper
            {
                result.approved = false;
                result.payout = 0;
                result.reasonCode = "NOT_COVERED";
                return result;
            }
            result.payout = Math.Min( claim.amountClaimed - deductible, coverageLimit);
            if (result.payout < 0m)
                result.payout = 0m;
            if (result.payout == 0m)
            {
                result.reasonCode = "ZERO_PAYOUT";
                result.approved = false; //assumsion
            }
            else
            {
                result.reasonCode = "APPROVED";
                result.approved = true; 

            }
            return result;
        }
    }
}
