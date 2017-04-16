using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required][StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Date Of Birth")]
        //[DataType(DataType.Date)]
        [Min18YearsIfAMember]
        public DateTime? Brithdate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership")]
        public byte MembershipTypeId { get; set; }



    }
}