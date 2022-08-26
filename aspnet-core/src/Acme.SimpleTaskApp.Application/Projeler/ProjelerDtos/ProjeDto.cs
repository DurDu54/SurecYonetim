using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos
{
    public class ProjeDto
    {
        public int ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public string Description { get; set; }
        public List<GorevDto> Gorevler { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string MusteriAdi { get; set; }
        public List<Developer> Developers { get; set; }
        public DurumEnum Durum { get; set; }
        public string ProjeDurum { get; set; }

        public bool IsDone { get; set; }



    }
}
