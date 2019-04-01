using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
      public interface IRegisterUser : IUserLogin
        {
            string FirstName { get; set; }
            string LastName { get; set; }
            string ConfirmPassword { get; set; }
            string IsStudent { get; set; }
        }

}