using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto
{
    public class YoneticiEkleDto
    {
        public int YoneticiId { get; set; }
        public int UserId { get; set; }
        public string YoneticiAdi { get; set; }

        public string Aciklama { get; set; }
        public string Iletisim { get; set; }
    }
}
