using Domain.Interfaces;

namespace Repository.Factory
{
    public interface IAuthenticationRepo
    {
        string ValidateLogin(Model loginModel);
         string RegisterUser(Model registrationModel);
        bool IsAlreadyRegistered(Model registrationModel);
    }
}




