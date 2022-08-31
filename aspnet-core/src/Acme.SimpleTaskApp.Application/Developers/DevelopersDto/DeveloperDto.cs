using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto
{
    public class DeveloperDto
    {
        public DeveloperDto()
        {
            this.ProjeAdlari = new List<string>();
        }
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
        public List<string> ProjeAdlari { get; set; }
        public string YoneticiAdi { get; set; }
        public string ProjeAdiTest
        {
            get
            {
                if (this.Projeler.Count == 0) return "";
                var test= this.Projeler.Aggregate("", (c, n) => c + ";" + n.Adi + ":" + n.ProjectId);
                return test.Remove(0, 1);
            }
        }
        public List<DeveloperProjectsDto> Projeler { get; set; }
    }
    public class DeveloperProjectsDto
    {
        public int ProjectId { get; set; }
        public string Adi { get; set; }
    }
}
