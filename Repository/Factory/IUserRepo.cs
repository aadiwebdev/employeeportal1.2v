using Domain.Enums;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Data;


namespace Repository.Factory
{
    public interface IUserRepo
    {
        List<Model> GetUserDetails(UserRoleChoice userRoleChoice);
         void ConvertToList(DataRow[] result);
    }
}
       