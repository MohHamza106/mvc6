using Data_Aceess_Layer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Data.Configration.Departement_related
{
    internal class Department_Configration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(D => D.Code).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(D => D.LastModifiedat).HasComputedColumnSql("GETDATE");
            builder.Property(D => D.createdon).HasDefaultValueSql("GETDATE");

        }
        
    }
   
}
