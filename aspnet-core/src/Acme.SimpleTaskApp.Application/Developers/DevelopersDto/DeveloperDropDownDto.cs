using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Developers.DevelopersDto
{
    public class DeveloperDropDownDto
    {        
        public string DeveloperName { get; set; }
        public long UserId { get; set; }

        public DeveloperDropDownDto(long userId,string developerName)
        {
            DeveloperName = developerName;
            UserId = userId;
        }
    }
}
