

using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace Domain
{
    public class ModelFactory
    {
        /// <summary>
        /// It is used to return appropriate object at runtime as per the requirement of the user/client
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public static  Model getModel(ModelSelection modelType)
        {
            Model model = null;
          if (modelType.Equals(ModelSelection.Login))
            {
                model = new LoginModel();
            }
            else if (modelType.Equals(ModelSelection.Register))
            {
                model = new RegistrationModel();
            }
            else if (modelType.Equals(ModelSelection.User))
            {
                model = new UserModel();
            }
            return model;
        }
    }
}