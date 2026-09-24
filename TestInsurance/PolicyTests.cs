using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceCore;
using System;
using System.Collections.Generic;

namespace TestInsurance
{
    [TestClass]
    class PolicyTests
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
            Assert.AreEqual(coveredIncidents, policy.coveredIncidents);

        }
    }
}
