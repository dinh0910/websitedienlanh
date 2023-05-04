using System.ComponentModel.DataAnnotations;
using XAct;

namespace websitedienlanh.Models
{
    public class ChiTietNhapHang
    {
        public int ChiTietNhapHangID { get; set; }

        public int NhapHangID { get; set; }
        public NhapHang? NhapHang { get; set; }

        public int SanPhamID { get; set; }
        public SanPham? SanPham { get; set; }

        public int DonViTinhID { get; set; }
        public DonViTinh? DonViTinh { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        public int SoLuong { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int ThanhTien { get; set; }
    }
}
