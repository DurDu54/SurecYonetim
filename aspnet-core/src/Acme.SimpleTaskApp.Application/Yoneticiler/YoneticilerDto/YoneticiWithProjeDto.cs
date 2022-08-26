using Acme.SimpleTaskApp.Projeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto
{
    public class YoneticiWithProjeDto
    {
        public int YoneticiId { get; set; }
        public string YoneticiAdi { get; set; }
        public string UserName { get; set; }
        public string Aciklama { get; set; }        
        //public List<Proje> Projeler { get; set; }
    }
}
