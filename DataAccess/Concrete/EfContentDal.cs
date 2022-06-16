using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfContentDal:EfEntityRepositoryBase<Content,NorthwindContext>,IContentDal
    {
    }
}
