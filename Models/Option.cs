using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrawlDataThongTinDoanhNghiep.Models
{
    public class Option
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RowPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string RequestUrl { get; set; }
        public string Keyword { get; set; }
        public int TotalRow { get; set; }
        public string NganhNgheID { get; set; }
        public string TinhThanhID { get; set; }
        public string QuanHuyenID { get; set; }
        public string PhuongXaID { get; set; }
    }
}
