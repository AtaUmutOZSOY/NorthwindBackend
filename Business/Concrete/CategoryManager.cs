using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("admin")]
        
        public IResult Add(Category category)
        {
            var isExistCategory = BusinessRulesValidator.Run(IsExistCategory(category.CategoryName));
            if (isExistCategory == null)
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(isExistCategory.Message);
        }

        private IResult IsExistCategory(string name)
        {
            var result = _categoryDal.Get(x => x.CategoryName == name);
            if (result !=null)
            {
                return new ErrorResult("Bu İsimde Bir Kategori Zaten Var");
            }
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            try
            {
                
                _categoryDal.Delete(category);
                return new SuccessResult();
            }
            catch (Exception)
            {
                throw ;
            }
        }




        public IDataResult<List<Category>> GetAll()
        {
            var categories = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(categories);
        }

        public IDataResult<Category> GetById(int id)
        {
            var category = _categoryDal.Get(x => x.CategoryId == id);
            if (category != null)
            {
                return new SuccessDataResult<Category>(category);
            }
            return null;
        }

        public IDataResult<Category> GetByName(string name)
        {
            var category = _categoryDal.Get(x => x.CategoryName == name);
            if (category != null)
            {
                return new SuccessDataResult<Category>(category);
            }
            return null;
        }

        public IResult Update(Category category)
        {
            var result = BusinessRulesValidator.Run(IsExistCategoryForUpdate(category.CategoryName));
            if (result.Success)
            {
                _categoryDal.Update(category);
            }
            return new ErrorResult();
        }

        private IResult IsExistCategoryForUpdate(string categoryName)
        {
            var result = _categoryDal.Get(x => x.CategoryName == categoryName);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<string>> GetAllCategoryNames()
        {
            var result = _categoryDal.GetAll();
            var categoryNames = new List<string>();
            
            foreach (var category in result)
            {
                categoryNames.Add(category.CategoryName);
            }
            return new SuccessDataResult<List<string>>(categoryNames);
        }
            
            
            
            

    }
}
