using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = validationContext.ObjectInstance as Customer;
            if (customer.MembershipTypeId== (byte)Membership.Unknow|| customer.MembershipTypeId==(byte)Membership.PayasYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Brithdate==null)
            {
                return new ValidationResult("Birthdate is Required");
            }
            int age = DateTime.Today.Year - customer.Brithdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("your age should be at least 18 years old");
        }
    }
}