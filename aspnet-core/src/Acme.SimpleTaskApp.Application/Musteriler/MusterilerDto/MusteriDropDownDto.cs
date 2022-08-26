using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Musteriler.MusterilerDto
{
    public class MusteriDropDownDto
    {      
        public string MusteriName { get; set; }
        public long UserId { get; set; }

        public MusteriDropDownDto(long userId, string musteriName)
        {
            
            MusteriName = musteriName;
            UserId = userId;
        }
    }
}
