using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.Certificates.Definitions
{
    public class FindExpiringInput
    {
        /// <summary>
        /// The task returns a list of certificates that expire in the given amount of days.
        /// </summary>
        [Required]
        [DefaultValue(60)]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The task returns a list of certificates that expire in the given amount of days.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("\"\"")]
        public string IssuedBy { get; set; }
    }
}
