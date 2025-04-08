using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CinemaTown.Models;

namespace CinemaTown.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="A Customer's name is required.")]
        [StringLength(50)]

        public string Name { get; set; }
        [Required(ErrorMessage ="A street adress is required.")]

        public string street_address { get; set; }
        [Required(ErrorMessage = "A city is required")]
        [StringLength(30)]
        public string city_address { get; set; }
        [Required(ErrorMessage = "A state is required")]
        [StringLength(2)]
        public string state_address { get; set; }
        [Required(ErrorMessage = "A zip code is required")]
        public int zip_adress { get; set; }
        [Required(ErrorMessage = "A phone number is required")]
        public long phone { get; set; }
        [EmailAddress]
        public string email_address { get; set; }
        //[ageValidation]
        public DateTime? birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        //public MembershipType MembershipType { get; set; }
        //[Display(Name = "Membership")]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}