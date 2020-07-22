using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMain.Models
{
    public class Customer
    {
        public int Id { get; set; } //Primary Key

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsMemberValidation]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; } //Foreign Key
    }
}