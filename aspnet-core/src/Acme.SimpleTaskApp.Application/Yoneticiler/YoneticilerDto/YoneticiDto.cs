using Acme.SimpleTaskApp.Projeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto
{
    public class YoneticiDto
    {
        public int YoneticiId { get; set; }
        public int UserId { get; set; }
        public string YoneticiName { get; set; }
        public string UserName { get; set; }
        public string Aciklama { get; set; }
        public string Iletisim { get; set; }
        // public List<Proje> ProjeList { get; set; }
    }
}
