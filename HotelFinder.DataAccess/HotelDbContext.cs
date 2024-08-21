//EF işlemleri yapacağımız için bize bir DbContext nesnesi lazım.
//Bu yüzden öncelikle bir class oluşturalım. İsmi HotelDbContext olsun.
//Bu classımız DbContexten miras alacak.
//DbContext’i nugetten bu katmana eklemeliyiz bu yüzden. MicrosoftEntityFrameworkCore.SqlServer’ı install edelim.

using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        //Burada ilk yapacağımız işlem OnConfiguring metodunu override edip ConnectionStringimizi vermek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=JARVIS\\SQLEXPRESS; Database=HotelDb; Integrated Security=True; MultipleActiveResultSets=False; Encrypt=False; TrustServerCertificate=False;");
            //Buraya Dbmizin ismini verdik ama Db'de böyle bir tablo yok.
            //Bu tabloyu da migration ile sağlayacağız.
        }

        public DbSet<Hotel> Hotels { get; set; }
        //Buradaki Hotel ile biz Entity katmanını buraya dahil ettik.
    }
}
