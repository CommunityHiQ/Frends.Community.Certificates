using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Frends.Community.Certificates.Definitions;
using Frends.Community.Certificates.Helpers;

#pragma warning disable 1591

namespace Frends.Community.Certificates
{
    public class Tools
    {
        /// <summary>
        /// Checks for certificates that expire before the given date from
        /// certificate stores of current user and local machine
        /// </summary>
        /// <returns>
        /// List of expiring certificates with the following
        /// information on each: Store path, Issuer and 
        /// Expiry date (as UTC, format yyyy-MM-ddThh:mm:ss)
        /// </returns>
        public static JToken FindExpiring(FindExpiringInput input)
        {
            StoreLocation[] locations = new StoreLocation[] { StoreLocation.CurrentUser, StoreLocation.LocalMachine };

            var expiresBy = DateTime.Now.AddDays(-input.ExpiresIn);
            var issuedBy = input.IssuedBy;

            JToken expiring;

            using (var writer = new JTokenWriter())
            {
                writer.Formatting = Formatting.Indented;
                writer.Culture = CultureInfo.InvariantCulture;
 
                writer.WriteStartArray();

                foreach (StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
                {
                    foreach (StoreName storeName in (StoreName[])Enum.GetValues(typeof(StoreName)))
                    {
                        X509Store store = new X509Store(storeName, storeLocation);
                        var storePath = storeLocation.ToString() + "/" + storeName.ToString();

                        try
                        {
                            store.Open(OpenFlags.ReadOnly);

                            if (!String.IsNullOrEmpty(input.IssuedBy))
                            {
                                // Extract issuer's CN value from Issuer and compare with IssuedBy
                                var certificate = store.Certificates.Cast<X509Certificate2>().FirstOrDefault(c => c.Issuer.Split(',')[0].ToLower().Replace("cn=","").Contains($"{issuedBy.ToLower()}"));

                                if (certificate != null)
                                {
                                    var expireDate = DateTime.Parse(certificate.NotAfter.ToString());

                                    if (expiresBy > expireDate)
                                    {
                                        writer.WriteCertificateInfo(storePath, certificate);
                                    }
                                }
                            }
                            else
                            {
                                foreach (X509Certificate2 certificate in store.Certificates)
                                {
                                    var expireDate = DateTime.Parse(certificate.NotAfter.ToString());

                                    if (expiresBy > expireDate)
                                    {
                                        writer.WriteCertificateInfo(storePath, certificate);
                                    }
                                }
                            }
                        }
                        catch (CryptographicException e)
                        {
                            throw new Exception("Error, certificate store not accesible", e);
                        }
                        finally
                        {
                            if (store != null)
                            {
                                store.Dispose();
                            }
                        }
                    }
                }
            writer.WriteEndArray();
            expiring = writer.Token;
            }
            // Add JArray to a JObject
            return Builders.BuildResult(expiring);
        }
    }
}
