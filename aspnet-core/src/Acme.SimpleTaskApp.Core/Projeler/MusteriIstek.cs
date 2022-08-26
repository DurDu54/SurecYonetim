using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    public class MusteriIstek : FullAuditedEntity
    {
        public int ProjeId { get; set; }
        public Proje proje { get; set; }        
        public Musteri Musteri { get; set; }
        [ForeignKey(nameof(MusteriId))]
        public int MusteriId { get; set; }
        public string  Istek { get; set; }
        public string Aciklama { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime DegistirmeTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string Document { get; set; }
    }
}
