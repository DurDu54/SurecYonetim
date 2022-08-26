using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto.DevelopersDto
{
    public class DevelopersCommitDto
    {
        //public int DeveloperId { get; set; }
        //public Gorev gorev { get; set; }
        //public int GorevId { get; set; }
        //public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public DurumEnum Durum { get; set; }
        public string DeveloperNot { get; set; }

    }
}
