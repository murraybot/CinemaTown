using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CinemaTown.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public short SignupFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
        [Required]

        public string Name { get; set; }

        public static readonly byte Uknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}