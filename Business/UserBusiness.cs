using Domain.Models;
using System.Collections.Generic;
using Repository;
using Domain.Enums;
using Domain.Interfaces;

namespace Business
{
    public class UserBusiness
    {
        UserRepo userRepo = new UserRepo();
        /// <summary>
        /// It is used to retrieve the details of userlist
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<Model> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            return userRepo.GetUserDetails(userRoleChoice);
        }
    }
}
