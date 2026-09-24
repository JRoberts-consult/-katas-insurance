using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceCore;
using System;
using System.Collections.Generic;

namespace TestInsurance
{
    [TestClass]
    public class PolicyTests
    {
        [TestMethod]
        [DataRow("1", "1/1/2000", "1/1/2000", 105.30, 105.30, "type1", "type2")]
        public void CreatePolicy(string policyId, string startDateString, string endDateString, double deductibleDouble, double coverageLimitDouble, params string[] coveredIncidentsArray)
        {
            DateTimeOffset startDate = DateTimeOffset.Parse(startDateString);
            DateTimeOffset endDate = DateTimeOffset.Parse(endDateString);
            decimal deductible = (decimal)deductibleDouble;
            decimal coverageLimit = (decimal)coverageLimitDouble;
            List<string> coveredIncidents = new List<string>(coveredIncidentsArray);

            Policy policy = new Policy(policyId, startDate, endDate, deductible, coverageLimit, coveredIncidents);
            Assert.AreEqual(policyId, policy.policyId);
            Assert.AreEqual(startDate, policy.startDate);
            Assert.AreEqual(endDate, policy.endDate);
            Assert.AreEqual(deductible, policy.deductible);
            Assert.AreEqual(coverageLimit, policy.coverageLimit);
            Assert.AreEqual(coveredIncidents, policy.coveredIncidents);// bad test here
        }
        [TestMethod]
        [DataRow(false, 0, "POLICY_INACTIVE", "1", "inc", "1/1/2005", 105.30, "1", "1/1/2000", "1/1/2000", 105.30, 105.30, "type1", "type2")]
        [DataRow(false, 0, "NOT_COVERED", "1", "inc", "1/1/2005", 105.30, "1", "1/1/2000", "1/1/2008", 105.30, 105.30, "type1", "type2")]
        [DataRow(false, 0, "ZERO_PAYOUT", "1", "type2", "1/1/2005", 105.30, "1", "1/1/2000", "1/1/2008", 105.30, 105.30, "type1", "type2")]
        [DataRow(true, 1000, "APPROVED", "1", "type2", "1/1/2005", 1105.30, "1", "1/1/2000", "1/1/2008", 105.30, 11105.30, "type1", "type2")]
        public void ProcessClaim(bool approved, double payout, string reasonCode, string policyIdClaim, string incidentType, string incidentDateString, double amountClaimedDouble,string policyId, string startDateString, string endDateString, double deductibleDouble, double coverageLimitDouble, params string[] coveredIncidentsArray)
        {
            DateTimeOffset incidentDate = DateTimeOffset.Parse(incidentDateString);
            decimal amountClaimed = (decimal)amountClaimedDouble;
            Claim claim = new Claim(policyId, incidentType, incidentDate, amountClaimed);

            DateTimeOffset startDate = DateTimeOffset.Parse(startDateString);
            DateTimeOffset endDate = DateTimeOffset.Parse(endDateString);
            decimal deductible = (decimal)deductibleDouble;
            decimal coverageLimit = (decimal)coverageLimitDouble;
            List<string> coveredIncidents = new List<string>(coveredIncidentsArray);
            Policy policy = new Policy(policyId, startDate, endDate, deductible, coverageLimit, coveredIncidents);

            ClaimResult expeected = new ClaimResult();
            expeected.approved = approved;
            expeected.payout = (decimal)payout;
            expeected.reasonCode = reasonCode;

            var result = policy.processClaim(claim);
            Assert.AreEqual(expeected.reasonCode, result.reasonCode);
            Assert.AreEqual(expeected.payout, result.payout);
            Assert.AreEqual(expeected.approved, result.approved);

        }
    }
}
