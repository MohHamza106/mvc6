using Data_Aceess_Layer.Entites.common.Enums;
using Data_Aceess_Layer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Data.Configration.EmployeeConfigration
{
     public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
     {
        public void Configure(EntityTypeBuilder<Employee> builder) 
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("nvarchar(100)");
            builder.Property(E => E.Address).HasColumnType("decimal(8,2)");
            builder.Property(D => D.LastModifiedat).HasComputedColumnSql("GETDATE");
            builder.Property(D => D.createdon).HasDefaultValueSql("GETDATE");

            builder.Property(E => E.gender).HasConversion(
                (gender) => gender.ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                );

            builder.Property(E => E.EmployeeType).HasConversion(
                (employee) => employee.ToString(),
                (employee) => (EmployeeType)Enum.Parse(typeof(Gender), employee)
                );
            builder.HasOne(E => E.Departments)
              .WithMany(D => D.Employees)
              .HasForeignKey(E => E.departmentsID)
              .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
