using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Species
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string? Voice { get; set; }
        public string? ImageLink { get; set; }
        public int LifeExpectancy { get; set; }
        public string Habitat { set; get; }
        public int? Total { get; set; }
        public IList<Bird>? Birds { get; set; }
        public IList<MealMenu>? MealMenus { get; set; }
    }
}
