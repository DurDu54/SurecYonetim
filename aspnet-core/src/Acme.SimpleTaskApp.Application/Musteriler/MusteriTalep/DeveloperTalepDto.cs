using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep
{
    public class DeveloperTalepDto
    {
        public Developer developer { get; set; }

        public int TalepId { get; set; }

        public Musteri musteri { get; set; }

        public string MusteriTalep { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarih { get; set; }
    }
}
