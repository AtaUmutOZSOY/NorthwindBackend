using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        IResult Add(Content content);
        IResult Delete(Content content);
        IResult Update(Content content);
        IDataResult<List<Content>> GetAll();
        IDataResult<Content> GetById(int id);
        IDataResult<Content> GetByName(string name);

    }
}
