using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SummonBonum.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Display(Name = "ProvinceName")]
        public string Name { get; set; }

        public List<City> Cities { get; set; }
        [Display(Name = "Picture")]
        public string PictureUrl { get; set; }
    }
}
