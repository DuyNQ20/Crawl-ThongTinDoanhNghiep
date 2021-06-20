using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICrawlDataThongTinDoanhNghiep.Models
{
    public class Tax
    {
        [Key]
        public string MaSoThue { get; set; }
        public int Type { get; set; }
        public string SolrID { get; set; }
        
        public DateTime NgayCap { get; set; }
        public string NgayDongMST { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string TitleEnAscii { get; set; }
        public string DiaChiCongTy { get; set; }
        public string DiaChiNhanThongBaoThue { get; set; }
        public string NamTaiChinh { get; set; }
        public string MaSoHienThoi { get; set; }
        public string NgayNhanToKhai { get; set; }
        public string NgayBatDauHopDong { get; set; }
        public string VonDieuLe { get; set; }
        public string TongSoLaoDong { get; set; }
        public string CapChuongLoaiKhoan { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string PhuongPhapTinhThueGTGT { get; set; }
        public string ChuSoHuu { get; set; }
        public string ChuSoHuu_DiaChi { get; set; }
        public string GiamDoc { get; set; }
        public string GiamDoc_DiaChi { get; set; }
        public string KeToanTruong { get; set; }
        public string KeToanTruong_DiaChi { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDelete { get; set; }
        public bool RequestChanged { get; set; }
        public bool ExitsInGDT { get; set; }
        public int SourceID { get; set; }
        public int TinhThanhID { get; set; }
        public string TinhThanhTitle { get; set; }
        public string TinhThanhTitleAscii { get; set; }
        public int QuanHuyenID { get; set; }
        public string QuanHuyenTitle { get; set; }
        public string QuanHuyenTitleAscii { get; set; }
        public string PhuongXaID { get; set; }
        public string PhuongXaTitle { get; set; }
        public string PhuongXaTitleAscii { get; set; }
        public string NoiDangKyQuanLyID { get; set; }
        public string NoiDangKyQuanLy_CoQuanTitle { get; set; }
        public string NoiDangKyQuanLy_CoQuanTitleAscii { get; set; }
        public string NoiDangKyQuanLy_DienThoai { get; set; }
        public string NoiDangKyQuanLy_Fax { get; set; }
        public string NoiNopThueID { get; set; }
        public string NoiNopThue_DienThoai { get; set; }
        public string NoiNopThue_Fax { get; set; }
        public string NoiNopThue_CoQuanTitle { get; set; }
        public string NoiNopThue_CoQuanTitleAscii { get; set; }
        public string QuyetDinhThanhLap { get; set; }
        public string QuyetDinhThanhLap_NgayCap { get; set; }
        public string QuyetDinhThanhLap_CoQuanCapID { get; set; }
        public string QuyetDinhThanhLap_CoQuanCapTitle { get; set; }
        public string QuyetDinhThanhLap_CoQuanCapTitleAscii { get; set; }
        public string GiayPhepKinhDoanh_CoQuanCapID { get; set; }
        public string GiayPhepKinhDoanh_CoQuanCapTitle { get; set; }
        public string GiayPhepKinhDoanh_CoQuanCapTitleAscii { get; set; }
        public string GiayPhepKinhDoanh { get; set; }
        public string GiayPhepKinhDoanh_NgayCap { get; set; }
        public string LoaiHinhID { get; set; }
        public string LoaiHinhTitle { get; set; }
        public string LoaiHinhTitleAscii { get; set; }
        public string NganhNgheID { get; set; }
        public string NganhNgheTitle { get; set; }
        public string NganhNgheTitleAscii { get; set; }
        [NotMapped]
        public List<string> DSNganhNgheKinhDoanh { get; set; }
        [NotMapped]
        public List<string> DSNganhNgheKinhDoanhID { get; set; }
        [NotMapped]
        public List<string> DSMaNganhNgheKinhDoanh { get; set; }
        public string Lv1 { get; set; }
        public string Lv2 { get; set; }
        public string Lv3 { get; set; }
        public string Lv4 { get; set; }
        public string Lv5 { get; set; }
        [NotMapped]
        public List<string> DSNganHang { get; set; }
        [NotMapped]
        public List<string> DSNganHangID { get; set; }
        [NotMapped]
        public List<string> DSThuePhaiNop { get; set; }
        [NotMapped]
        public List<string> DSThuePhaiNopID { get; set; }
        [NotMapped]
        public List<string> LtsDoanhNghiepTrucThuoc { get; set; }
        [NotMapped]
        public List<string> DSTags { get; set; }
    }
}
