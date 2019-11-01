using Newtonsoft.Json.Linq;

#pragma warning disable 1591

namespace Frends.Community.Certificates.Helpers
{
    public static class Builders
    {
        public static JObject BuildResult(JToken expiring)
        {
            JObject result;

            if (expiring.HasValues == false)
            {
                result = new JObject(
                    new JProperty("Found expiring", false),
                    new JProperty("Expiring", new JArray())
                    );
            }
            else
            {
                result = new JObject(
                    new JProperty("Found expiring", true),
                    new JProperty("Expiring", expiring)
                    );
            }

            return result;
        }
    }
}
