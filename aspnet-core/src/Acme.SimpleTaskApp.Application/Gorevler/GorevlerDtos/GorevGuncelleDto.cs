using Acme.SimpleTaskApp.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos
{
    public class GorevGuncelleDto
    {
        
        public long GorevId { get; set; }
        public string GorevTanimi { get; set; }
        public string GorevAciklama { get; set; }
        public int DeveloperId { get; set; }
        public int ProjeId { get; set; }
        public DurumEnum Durum { get; set; }
        public string GorevDurum { get; set; }
        public DateTime BaslamaZamani { get; set; }


    }
}
