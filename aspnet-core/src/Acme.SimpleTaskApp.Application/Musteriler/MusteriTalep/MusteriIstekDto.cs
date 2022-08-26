using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep
{
    public class MusteriIstekDto
    {
        public int ProjeId { get; set; }
        public Proje Proje { get; set; }
        public string ProjeAdi { get; set; }
        public int MusteriIstekId { get; set; }

        public string MusteriAdi { get; set; }
        public Musteri Musteri { get; set; }

        public string MusteriIstek { get; set; }
        public string MusteriAciklama { get; set; }
        public DateTime BaslangicTarih { get; set;}

        public DateTime BitisTarih { get; set; }

    }
}
