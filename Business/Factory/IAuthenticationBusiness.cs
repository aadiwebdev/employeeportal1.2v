using Domain.Interfaces;

namespace Business.Factory
{
    public interface IAuthenticationBusiness
    {
         string ValidateLogin(Model loginModel);
        string RegisterUser(Model registrationModel);
    }
}
        
