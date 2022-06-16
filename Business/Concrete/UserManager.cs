using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = BusinessRulesValidator.Run(CheckExistUser(user.Email));
            if (result == null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.UserMassages.UserAlreadyExist);
        }

        public IDataResult<List<User>> GetAll()
        {
            var users = _userDal.GetAll();
            if (users != null)
            {
                return new SuccessDataResult<List<User>>(users);
            }
            return null;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var claims = _userDal.GetClaims(user);
            if (claims != null)
            {
                return new SuccessDataResult<List<OperationClaim>>(claims);
            }
            return null;
        }


        public IDataResult<User> GetUser(string email)
        {
            var user = _userDal.Get(x => x.Email == email);
            return new SuccessDataResult<User>(user);
        }
        public IResult CheckExistUser(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
