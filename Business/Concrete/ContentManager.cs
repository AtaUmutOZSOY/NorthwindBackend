using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public IResult Add(Content content)
        {
            var result = BusinessRulesValidator.Run(CheckExistContentByContentName(content.ContentName));
            if (result == null)
            {
                _contentDal.Add(content);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.AlreadyExist);
        }

        private IResult CheckExistContentByContentName(string contentName)
        {
            var result = _contentDal.Get(x => x.ContentName == contentName);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Content content)
        {
            try
            {
                _contentDal.Delete(content);
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IDataResult<List<Content>> GetAll()
        {
            var contents = _contentDal.GetAll();
            if (contents != null)
            {
                return new SuccessDataResult<List<Content>>(contents);
            }
            return null;
        }


        public IDataResult<Content> GetById(int id)
        {
            var content = _contentDal.Get(x => x.Id == id);
            if (content != null)
            {
                return new SuccessDataResult<Content>(content);
            }
            return null;
        }

        public IDataResult<Content> GetByName(string name)
        {
            var content= _contentDal.Get(x => x.ContentName == name);
            if (content!= null)
            {
                return new SuccessDataResult<Content>(content);
            }
            return null;
        }

        public IResult Update(Content content)
        {
            var result = BusinessRulesValidator.Run(CheckExistContentByContentNameForUpdate(content.ContentName));
            if (result.Success)
            {
                _contentDal.Update(content);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);

        }

        private IResult CheckExistContentByContentNameForUpdate(string contentName)
        {
            var result = _contentDal.Get(x => x.ContentName == contentName);
            if (result !=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
