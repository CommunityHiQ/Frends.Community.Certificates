using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

#pragma warning disable 1591

namespace Frends.Community.Certificates.Helpers
{
    public static class Extensions
    {
        public static void WriteCertificateInfo(this JTokenWriter writer, string storePath, X509Certificate2 cert)
        {
            var issuer = cert.Issuer;
            var notAfter = cert.NotAfter.ToString();
            writer.WriteStartObject();
            writer.WritePropertyName("Store Path");
            writer.WriteValue(storePath);
            writer.WritePropertyName("Issuer");
            writer.WriteValue(issuer);
            writer.WritePropertyName("Expiry date");
            writer.WriteValue(notAfter);
            writer.WriteEndObject();
        }
    }
}
