using Frends.Community.Certificates;
using Frends.Community.Certificates.Definitions;
using NUnit.Framework;

namespace Frends.Community.Certificates.Framework452Test
{
    [TestFixture]
    public class ToolTests_FW
    {
        private readonly FindExpiringInput _input = new FindExpiringInput();

        [SetUp]
        public void Setup()
        {
            _input.ExpiresIn = 60;
        }

        [Test]
        public void TestFindExpiring()
        {
            // Test fetching all expiring certificates
            var result = Tools.FindExpiring(_input);
            Assert.That(result.ToString() != "");
        }

        [Test]
        public void TestFindExpiringByIssuer()
        {
            // Test fetching all expiring certificates for certain issuer
            _input.IssuedBy = "HFWS155";
            var result = Tools.FindExpiring(_input);
            Assert.That(result.ToString() != "");
        }
    }
}
