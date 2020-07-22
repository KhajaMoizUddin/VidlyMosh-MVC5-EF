using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMain.Models
{
    public class Min18YearsMemberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == MembershipType.Unknown || customer.MemberShipTypeId == MembershipType.PayAsYouGo) //Validation should be applied to other than Pay as you Go
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is required");

            var minimumAge = DateTime.Today.Year - Convert.ToInt32(customer.BirthDate.Value.Year);
            return minimumAge >= 18
                ? ValidationResult.Success
                : new ValidationResult("Age should be greater than 18 for membership");
        }
    }
}