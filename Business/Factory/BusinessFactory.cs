using Domain.Enums;
using Domain.Interfaces;

namespace Business.Factory
{
    public class BusinessFactory
    {
        public static IUserBusiness GetUserBusiness()
        {
            return new UserBusiness();
        }

        public static IAuthenticationBusiness GetAuthentication()
        {
            return  new AuthenticationBusiness();
        }
    }
}
