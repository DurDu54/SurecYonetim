using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    
    public class Proje : FullAuditedEntity
    {
        
        public string ProjeAdi { get; set; }
        public string Description { get; set; }
        public DurumEnum Durum { get; set; }
        public string ProjeDurum { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime MusteriBitisTarihi { get; set; }
        [ForeignKey(nameof(MusteriId))]
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public virtual ICollection<Developer> Developerlar { get; set; }
        public ProjeYonetici ProjeYoneticisi { get; set; }
        public int? ProjeYoneticisiId { get; set; }
        public bool IsDone { get; set; }

    }

}
