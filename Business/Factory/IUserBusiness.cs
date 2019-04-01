using Domain.Enums;
using Domain.Interfaces;
using System.Collections.Generic;


namespace Business.Factory
{
    public interface IUserBusiness
    {
        List<Model> GetUserDetails(UserRoleChoice userRoleChoice);
    }
}
