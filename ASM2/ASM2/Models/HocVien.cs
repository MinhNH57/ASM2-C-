namespace ASM2.Models
{
    public class HocVien
    {
        //Tạo đối tượng HocVien ở Thư mục Model chứa các thông tin sau: ID: Guid, HoTen: string, Tuoi: int,
        public Guid ID { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string? chuyennghanh { get; set; }

        public string? MaKhoa { get; set; } 
        public virtual KhoaHoc? Course { get; set; }


    }
}
