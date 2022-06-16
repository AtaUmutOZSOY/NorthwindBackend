using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.DTOs
{
    public class BrandDTO:IDto
    {
        public string CurrentBrandName { get; set; }
        public string NewBrandName { get; set; }
    }
}
