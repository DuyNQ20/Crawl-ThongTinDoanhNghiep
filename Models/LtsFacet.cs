using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrawlDataThongTinDoanhNghiep.Models
{
    public class LtsFacet
    {
        public int ID { get; set; }
        public string UrlFacet { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }
    }
}
