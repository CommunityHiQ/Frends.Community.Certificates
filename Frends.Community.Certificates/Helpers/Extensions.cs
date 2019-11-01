using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

#pragma warning disable 1591

namespace Frends.Community.Certificates.Helpers
{
    public static class Extensions
    {
        public static void WriteCertificateInfo(this JTokenWriter writer, string storePath, X509Certificate2 cert)
        {
            var issuer = cert.GetNameInfo(X509NameType.SimpleName, true);
            var notAfter = cert.NotAfter.ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture);
            writer.WriteStartObject();
            writer.WritePropertyName("Store path");
            writer.WriteValue(storePath);
            writer.WritePropertyName("Issuer");
            writer.WriteValue(issuer);
            writer.WritePropertyName("Expiry date (UTC)");
            writer.WriteValue(notAfter);
            writer.WriteEndObject();
        }
    }
}
