using Abp.Domain.Entities.Auditing;
using Abp.Timing;
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
    [Table("Gorevler")]

    public class Gorev : FullAuditedEntity
    {
        [ForeignKey(nameof(ProjeId))]
        public Proje Proje { get; set; }
        public int ProjeId { get; set; }
        [ForeignKey(nameof(DeveloperId))]
        public Developer Developer { get; set; }
        public int? DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public string GorevTanimi { get; set; }
        public string GorevAciklama { get; set; }
        public DurumEnum Durum { get; set; }
        public string GorevDurum { get; set; }
        public DateTime BaslamaZamani { get; set; }
        public DateTime BitirmeZamani { get; set; }
        public string DeveloperNot { get; set; }
       


    }
}
