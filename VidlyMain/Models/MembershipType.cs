using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyMain.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationsInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public string Name { get; set; }
        public string BirthDate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}