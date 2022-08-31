using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskApp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    [Table("Developers")]
    public class Developer : FullAuditedEntity
    {
        public string DeveloperName { get; set; }
        public string DeveloperSide { get; set; }
        public int DeveloperCommits { get; set; }

        public User User { get; set; }
        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }

        public ProjeYonetici Yonetici { get; set; }
        public int? YoneticiId { get; set; }

        public ICollection<Proje> Projeler { get; set; }

        public int? ProjeId { get; set; }



    }
}
