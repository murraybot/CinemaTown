using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CinemaTown.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="A customer name is required")]
        [StringLength(45)]
        public string Name { get; set; }
        [Required(ErrorMessage ="A street address is required")]
        [StringLength(30)]
        [Display(Name = "Street Address")]
        public string street_address { get; set; }
        [Required(ErrorMessage ="A city is required")]
        [StringLength(30)]
        public string city_address { get; set; }
        [Required(ErrorMessage ="A state is required")]
        [StringLength(2)]
        public string state_address { get; set; }
        [Required(ErrorMessage ="A zip code is required")]
        public int zip_adress {get; set;}
        [Required(ErrorMessage ="A phone number is required")]
        public long phone { get; set; }
        [EmailAddress]
        public string email_address { get; set; }
        [ageValidation]
        public DateTime? birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name ="Membership")]
        public byte MembershipTypeId { get; set; }
    }
}