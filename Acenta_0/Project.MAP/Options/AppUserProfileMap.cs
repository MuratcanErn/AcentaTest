using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserProfileMap : BaseMap<AppUserProfile>
    {
        public AppUserProfileMap()

        {
            ToTable("Profiller");
           
            Property(x => x.Street).HasColumnName("Sokak").IsRequired();
            Property(x => x.Email).HasColumnName("Mail").IsRequired();
            Property(x => x.TelNo).HasColumnName("TelefonNumarasi").IsRequired();
            Property(x => x.City).HasColumnName("Sehir").IsRequired();
            Property(x => x.Country).HasColumnName("Ulke").IsRequired();
            Property(x => x.PostCode).HasColumnName("PostaKodu").IsRequired();
            Property(x => x.FaxNo).HasColumnName("FaxNo").IsRequired();

        }
    }
}
