using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    enum Membership:byte
    {
        Unknow=0,
        PayasYouGo=1,
        Monthly,
        Quarterly,
        Annual
    }
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SingnUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }


    }
}