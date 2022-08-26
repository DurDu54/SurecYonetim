using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto
{
    public class ProjeListForYonetici
    {
        public int ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
    }
}
