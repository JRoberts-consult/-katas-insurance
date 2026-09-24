using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceCore;
using System;

namespace TestInsurance
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        [DataRow("1", "inc", "1/1/2000", 105.30)]
        public void CreateClaim(string policyId, string incidentType, string incidentDateString, double amountClaimedDouble)
        {
            DateTimeOffset incidentDate = DateTimeOffset.Parse(incidentDateString);
            decimal amountClaimed = (decimal)amountClaimedDouble;
            Claim claim = new Claim(policyId, incidentType, incidentDate, amountClaimed);
            Assert.AreEqual(policyId, claim.policyId);
            Assert.AreEqual(incidentType, claim.incidentType);
            Assert.AreEqual(incidentDate, claim.incidentDate);
            Assert.AreEqual(amountClaimed, claim.amountClaimed);
        }
    }
}
