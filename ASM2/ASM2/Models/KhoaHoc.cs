using System.ComponentModel.DataAnnotations;

namespace ASM2.Models
{
    public class KhoaHoc
    {
        [Key]
       public string ID { get; set; }
       public string TenKhoa { get; set; }
       public int namHoc { get; set; }
       public virtual ICollection<HocVien> HocViens { get; set; }
    }
}
