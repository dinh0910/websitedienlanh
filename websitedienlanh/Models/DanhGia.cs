namespace websitedienlanh.Models
{
    public class DanhGia
    {
        public int DanhGiaID { get; set; }

        public int SanPhamID { get; set; }

        public string? HoTen { get; set; }

        public string? Sdt { get; set; }

        public int MucDo { get; set; }
    }
}
