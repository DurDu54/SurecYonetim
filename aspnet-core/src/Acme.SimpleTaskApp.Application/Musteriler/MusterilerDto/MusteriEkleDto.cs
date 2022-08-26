using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos
{
    public class MusteriEkleDto
    {
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string Iletisim { get; set; }
        public string Aciklama { get; set; }
        public long UserId { get; set; }
    }
}
