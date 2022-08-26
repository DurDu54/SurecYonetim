using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos
{
    public class GorevEkleDto
    {       
        public string GorevTanimi { get; set; }
        public int DeveloperId { get; set; }
        public int ProjeId { get; set; }
        public DurumEnum Durum { get; set; }
        public DateTime BaslamaZamani { get; set; }
        public string GorevAciklama { get; set; }
    }
    
}
