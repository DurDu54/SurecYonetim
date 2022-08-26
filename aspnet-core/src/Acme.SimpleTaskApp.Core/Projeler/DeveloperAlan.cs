using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    public class DeveloperAlan : FullAuditedEntity
    {
        public string DeveloperAlani { get; set; }
    }
}
