using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICrawlDataThongTinDoanhNghiep.Models
{
    public class Root
    {
        public int ID { get; set; }
        public string HtmlPage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string SolrID { get; set; }
        [NotMapped]
        public Option Option { get; set; }
        [NotMapped]
        public List<LtsMap> LtsMaps { get; set; }
        public string TitleFacet { get; set; }
        [NotMapped]
        public List<LtsFacet> LtsFacets { get; set; }
        public string LtsFacetOption { get; set; }
        [NotMapped]
        public List<string> LtsFacetNganhNgheKinhDoanh { get; set; }
        [NotMapped]
        public List<Tax> LtsItems { get; set; }
    }
}
