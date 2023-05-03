using System.ComponentModel.DataAnnotations;

namespace websitedienlanh.Models
{
    public class DonDatHang
    {
        public int DonDatHangID { get; set; }

        public DateTime NgayLap { get; set; }

        public string? HoTen { get; set; }

        public string? Sdt { get; set; }

        public string? DiaChi { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TongTien { get; set; }
    }
}
