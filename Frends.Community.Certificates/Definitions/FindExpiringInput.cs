using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591

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
        /// Optional parameter for searching expiring certificates from a specific issuer.
        /// Filter's based on CN, does not find certificates with no CN. 
        /// Can be either issuer's full name or part of the issuer's name.
        /// Case insensitive. Note: CNs that contain the character ',' are currently not handled correctly.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("\"\"")]
        public string IssuedBy { get; set; }
    }
}
