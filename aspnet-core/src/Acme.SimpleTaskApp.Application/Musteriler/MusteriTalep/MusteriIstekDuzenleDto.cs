using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep
{
    public class MusteriIstekDuzenleDto
    {
        public int MusteriIstekId { get; set; }       
        public int ProjeId { get; set; }
        //public int MusteriTalepId { get; set; } 
        public int MusteriId { get; set; }
        public string MusteriIstek { get; set; }
        public string MusteriAciklama { get; set; }
        public DateTime BaslangicTarih { get; set; }

        

    }
}
