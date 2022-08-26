using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskApp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    public class ProjeYonetici:FullAuditedEntity
    {
         
        public string ProjeYoneticisiAdi { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }

        public string Iletisim { get; set; }
        public string Aciklama { get; set; }

    }
}
