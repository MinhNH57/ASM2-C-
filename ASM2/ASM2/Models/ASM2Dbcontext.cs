using Microsoft.EntityFrameworkCore;

namespace ASM2.Models
{
    public class ASM2Dbcontext : DbContext
    {
        public ASM2Dbcontext(DbContextOptions<ASM2Dbcontext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RTLBH4I\\SQLEXPRESS;Database=ASM2;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HocVien>().HasData(

                new HocVien { ID = Guid.NewGuid(), HoTen = "Nguyen Hong Minh", Tuoi = 20, chuyennghanh = "CNTT"}
                );
            modelBuilder.Entity<KhoaHoc>().HasData(
                new KhoaHoc { ID = "SD18401", TenKhoa = "PTPM98" , namHoc  = 2022 }
                );
        }
    }
}
