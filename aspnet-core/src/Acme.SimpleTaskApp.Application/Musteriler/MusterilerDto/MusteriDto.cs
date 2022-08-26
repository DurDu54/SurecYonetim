using Abp.Authorization.Users;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos
{
    public class MusteriDto

    {
        public int? MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string Iletisim { get; set; }
        public string Aciklama { get; set; }
        public User Users { get; set; }


        public long UserId { get; set; }
        public string Username { get; set; }

       


    }
}
