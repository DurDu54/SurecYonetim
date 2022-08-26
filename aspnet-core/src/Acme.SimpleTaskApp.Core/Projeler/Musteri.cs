using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskApp.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.SimpleTaskApp.Projeler
{
    [Table("Musteriler")]
    public class Musteri : FullAuditedEntity
    {
        public string MusteriAdi { get; set; }
        public string Iletisim { get; set; }
        public string Aciklama { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }


    }
}
