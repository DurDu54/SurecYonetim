using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto
{
    public class YoneticiDropDownDto
    {
        public long UserId { get; set; }
        public string YoneticiName { get; set; }


        public YoneticiDropDownDto(long userId,string yoneticiName)
        {
            UserId = userId;
            YoneticiName = yoneticiName;
        }
    }
}
