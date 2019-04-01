using Domain.StringLiterals;
using System.Configuration;
using System.Data.SqlClient;
using Domain.Interfaces;
using Repository.Factory;

namespace Repository
{
    public class AuthenticationRepo:IAuthenticationRepo
    {
        /// <summary>
        /// It is used to validate login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(Model loginModel)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeportal"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(StringLiterals._validateLoginQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailAddress", loginModel.EmailAddress);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);
                    return  (int)command.ExecuteScalar()==1 ? StringLiterals._loginSuccess : StringLiterals._loginFailed;
                }
            }
        }
        /// <summary>
        /// It is used to register user.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(Model registrationModel)
        {
            Model  userModel = registrationModel.GetMappedObject();
            if (!IsAlreadyRegistered(userModel))
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeportal"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(StringLiterals._insertCommand, connection))
                    {

                        command.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                        command.Parameters.AddWithValue("@LastName", userModel.LastName);
                        command.Parameters.AddWithValue("@EmailAddress", userModel.EmailAddress);
                        command.Parameters.AddWithValue("@Password", userModel.Password);
                        command.Parameters.AddWithValue("@IsStudent", userModel.IsStudent);
                        if (command.ExecuteNonQuery() >= 1)
                        {
                            return StringLiterals._success;
                        }
                    }
                }
            }
            return StringLiterals._registrationFailed;
        }
        /// <summary>
        /// It is to check whelther user is already registered or not.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public  bool IsAlreadyRegistered(Model registrationModel)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeportal"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(StringLiterals._alreadyUserRegisteredQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailAddress", registrationModel.EmailAddress);
                    return (int)command.ExecuteScalar() > 0 ? true : false;  
                }
            }
        }
    }
}