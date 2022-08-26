using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Acme.SimpleTaskApp.Authorization.Roles;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.MultiTenancy;
using Acme.SimpleTaskApp.Projeler;

namespace Acme.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpZeroDbContext<Tenant, Role, User, SimpleTaskAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
      
        //public DbSet<Sandalye> Sandalyeler { get; set; }
        //public DbSet<Sehpa> Sehpalar { get; set; }
        //public DbSet<Televizyon> Televizyonlar { get; set; }
        //public DbSet<Masa> Masalar { get; set; }
        //public DbSet<Cuzdan> Cuzdanlar { get; set; }
        //public DbSet<Agac> Agaclar { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Proje> Proje { get; set; }
        public DbSet<MusteriIstek> MusteriIstek { get; set; }
        public DbSet<ProjeYonetici> ProjeYoneticisi { get; set; }
        public DbSet<DeveloperAlan> DeveloperAlani { get; set; }    
        public DbSet<ProjeDurum> ProjeDurum { get; set; }    
        public DbSet<GorevDurum> GorevDurum { get; set; }

        //public DbSet<ProjeUser> ProjeUser { get;  set; }


        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options)
            : base(options)
        {
        }
    }
}
