using Domain.Interfaces;
using Domain.Models;
using Domain.StringLiterals;
using Repository;
using System;

namespace Business
{
    public class AuthenticationBusiness
    {
        AuthenticationRepo authRepo;
        public AuthenticationBusiness()
        {
            authRepo = new AuthenticationRepo();

        }
        /// <summary>
        /// It is used to validate user credencials
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(Model loginModel)
        {
            if (Validations.ValidateEmailAddress(loginModel.EmailAddress).Equals(StringLiterals._success))
            {
                if (Validations.ValidatePassword(loginModel.Password).Equals(StringLiterals._success))
                {
                    return authRepo.ValidateLogin(loginModel);
                }
                return Validations.ValidatePassword(loginModel.Password);
            }
            return Validations.ValidateEmailAddress(loginModel.EmailAddress);
        }
        /// <summary>
        /// It is used to register the user
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(Model registrationModel)
        {
            if (Validations.ValidateEmailAddress(registrationModel.EmailAddress).Equals(StringLiterals._success))
            {
                if (Validations.ValidatePassword(registrationModel.Password).Equals(StringLiterals._success))
                {
                    return authRepo.RegisterUser(registrationModel);
                }
                return Validations.ValidatePassword(registrationModel.Password);
            }
            return Validations.ValidateEmailAddress(registrationModel.EmailAddress);

        }
    }
}
