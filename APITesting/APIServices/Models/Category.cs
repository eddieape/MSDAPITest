using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set; }
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public long DefaultDuration { get; set; }
        public List<long> AllowedDurations { get; set; }
        public Fees Fees { get; set; }
        public long FreePhotoCount { get; set; }
        public long MaximumPhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<object> EmbeddedContentOptions { get; set; }
        public long MaximumTitleLength { get; set; }
        public long AreaOfBusiness { get; set; }
        public long DefaultRelistDuration { get; set; }
        public bool CanUseCounterOffers { get; set; }
    }
}
