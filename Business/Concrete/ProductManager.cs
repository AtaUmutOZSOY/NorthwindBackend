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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            var result = BusinessRulesValidator.Run(CheckExistProduct(product.ProductId));
            if (result.Success)
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddAdd);
        }

        private IResult CheckExistProduct(int productId)
        {
            var existProduct = _productDal.Get(x => x.ProductId == productId);
            if (existProduct != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<List<Product>> GetAll()
        {
           var products =  _productDal.GetAll();
            if (products != null)
            {
                return new SuccessDataResult<List<Product>>(products);
            }
            return null;
        }

        public IDataResult<Product> GetById(int productId)
        {
            var product = _productDal.Get(x => x.ProductId == productId);
            if (product != null)
            {
                return new SuccessDataResult<Product>(product);
            }
            return null;
        }

        public IResult Update(Product product)
        {
            var result = BusinessRulesValidator.Run(CheckExistProductForUpdate(product.ProductId));
            if (result.Success)
            {
                _productDal.Update(product);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ActionMessages.UnsuccedUpdate);
        }


        private IResult CheckExistProductForUpdate(int id)
        {
            var existProduct = _productDal.Get(x => x.ProductId == id);
            if (existProduct != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
