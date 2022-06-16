using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Content:IEntity
    {
        public int Id { get; set; }
        public string ContentName { get; set; }

    }
}
