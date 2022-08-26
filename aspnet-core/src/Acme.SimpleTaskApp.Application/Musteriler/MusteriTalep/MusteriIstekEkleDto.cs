using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep
{
    public class MusteriIstekEkleDto
    {
        public int ProjeId { get; set; }       
        public int MusteriIstekId { get; set; }        
        public int MusteriId { get; set; }
        public string MusteriTalep { get; set; }
        public string MusteriAciklama { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public IFormFile Document { get; set; }        
    }
}
