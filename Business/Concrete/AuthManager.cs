using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Entity.Concrete;
using Core.Entity.DTOs;
using Core.Utilities.Helper.HashingHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
      
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
           
        }
       
        public IDataResult<User> Register(UserRegisterDto userForRegisterDto, string password)
        {
            var IsExistValidation = BusinessRulesValidator.Run(CheckUserExistForRegister(userForRegisterDto.Email));

            if (IsExistValidation == null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    FindexPoint = 1500
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user , Messages.AuthMessages.SucceedUserRegistiration);
            }
            return new ErrorDataResult<User>(IsExistValidation.Message);
        }

        private IResult CheckUserExistForRegister(string email)
        {
            var user = _userService.GetUser(email);
            if (user.Data == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckUserExistForLogin(string email)
        {
            var user = _userService.GetUser(email);
            if (user.Data != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            

            var getExistUser = _userService.GetUser(userForLoginDto.Email);
            
            if (!getExistUser.Success)
            {   
                return new ErrorDataResult<User>(Messages.UserMassages.UserNotFound);
            }
              
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, getExistUser.Data.PasswordHash, getExistUser.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.AuthMessages.RegistirationDenied);
            }
            return new SuccessDataResult<User>(getExistUser.Data,  Messages.AuthMessages.SuccessLogin);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,  Messages.AuthMessages.AccessTokenCreated);
        }
    }
}
              
              




    




