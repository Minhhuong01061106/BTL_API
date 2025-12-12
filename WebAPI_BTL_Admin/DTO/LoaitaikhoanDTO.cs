namespace DTO
{
    public class LoaitaikhoanDTO
    {
        public int Idloaitaikhoan { get; set; }
        public string Tenloaitaikhoan { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
