using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    public class ProjeUser : FullAuditedEntity

    {

        //    public virtual Proje Proje{ get; set; }
        //    public virtual User User { get; set; }
        public DateTime Tarih { get; set; }
    }
}
