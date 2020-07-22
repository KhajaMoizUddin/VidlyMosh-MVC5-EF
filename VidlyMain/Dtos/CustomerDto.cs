using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMain.Models;

namespace VidlyMain.Dtos
{
    public class CustomerDto  // Data Transfer Object for Loose Coupling of Code
    {
        public int Id { get; set; } //Primary Key

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Min18YearsMemberValidation]
        public DateTime? BirthDate { get; set; }

        public byte MemberShipTypeId { get; set; } //Foreign Key
    }
}