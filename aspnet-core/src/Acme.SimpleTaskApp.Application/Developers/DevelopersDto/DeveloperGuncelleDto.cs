using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Developers.DevelopersDto
{
    public class DeveloperGuncelleDto
    {
        public int DeveloperId { get; set; }
        public string DeveloperAdi { get; set; }
        public string DeveloperSide { get; set; }
        public int? ProjeId { get; set; }
        public int DeveloperCommits { get; set; }

        public int? YoneticiId { get; set; }

    }
}
