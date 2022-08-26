using Acme.SimpleTaskApp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto
{
    public class DeveloperDto
    {
        public int DeveloperId { get; set; }
        public User User { get; set; }

        public long UserId { get; set; }
        public string Username { get; set; }

        public string DeveloperName { get; set; }
        public string DeveloperSide { get; set; }

        public int DeveloperCommits { get; set; }

        //public Proje Proje { get; set; }
        public int? ProjeId { get; set; }

        //public ProjeYonetici Yonetici { get; set; }
        public int? YoneticiId { get; set; }
        public string ProjeAdi { get; set; }
        public string YoneticiAdi { get; set; }

    }
}
