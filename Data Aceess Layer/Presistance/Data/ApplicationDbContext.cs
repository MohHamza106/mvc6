using Data_Aceess_Layer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextoptionBuldier optionbuilder)
        //{
        //    optionbuilder.UseSqlServer("Server = . ; Database=MVCProject ; Trusted_Connection=true; TrustedServerCertificate=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Departments> Departments {  get; set; }
        public DbSet<Employee> Employees { get; set; }  
    }
}
