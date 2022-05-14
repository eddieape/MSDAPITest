using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models
{
    public class Fees
    {
        public long Bundle { get; set; }
        public double EndDate { get; set; }
        public long Feature { get; set; }
        public long Gallery { get; set; }
        public long Listing { get; set; }
        public double Reserve { get; set; }
        public double Subtitle { get; set; }
        public double TenDays { get; set; }
        public List<ListingFeeTier> ListingFeeTiers { get; set; }
        public double SecondCategory { get; set; }
    }

    public class ListingFeeTier
    {
        public long MinimumTierPrice { get; set; }
        public long FixedFee { get; set; }
    }
}
