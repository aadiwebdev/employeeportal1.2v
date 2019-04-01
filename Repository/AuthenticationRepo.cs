using Domain;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Domain.StringLiterals;
using System;
using System.Linq;

namespace Repository
{
    public class AuthenticationRepo
    {
        /// <summary>
        /// It is used to validate login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(Model loginModel)
        {
            if (DataSource._userList.Any(m => m.EmailAddress == loginModel.EmailAddress && m.Password == loginModel.Password))
            {
                return StringLiterals._success;
            }
            return StringLiterals._loginFailed;
        }
        /// <summary>
        /// It is used to register user.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(Model registrationModel)
        {
           Model userModel = registrationModel.GetMappedObject();
            Console.WriteLine("The value is :" + userModel.FirstName);
            if (!DataSource._userList.Any(m => m.EmailAddress == userModel.EmailAddress))
            {
               DataSource._userList.Add(userModel);
                return StringLiterals._success;
            }
            return StringLiterals._registrationFailed;
        }
    }
}




using Domain.StringLiterals;
using System.Linq;
using System;
using Domain.Models;
using System.Data.SqlClient;

namespace Repository
{
    public class AuthenticationRepo
    {
        /// <summary>
        /// It is used to validate login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(LoginModel loginModel)
        {
            using (SqlConnection connection = new SqlConnection(StringLiterals._connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(StringLiterals._validateLoginQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@EmailAddress", loginModel.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", loginModel.Password);
                    if (cmd.ExecuteReader().HasRows)
                    {
                        return StringLiterals._success;
                    }
                }
            }
            return StringLiterals._loginFailed;
        }
        /// <summary>
        /// It is used to register user.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(RegistrationModel registrationModel)
        {
            DataLayer.UserModel userModel = registrationModel.GetMappedObject();
            if (!IsAlreadyRegistered(registrationModel))
            {
                using (SqlConnection connection = new SqlConnection(StringLiterals._connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(StringLiterals._insertCommand, connection))
                    {
                        Console.WriteLine(userModel.FirstName);
                        cmd.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", userModel.LastName);
                        cmd.Parameters.AddWithValue("@EmailAddress", userModel.EmailAddress);
                        cmd.Parameters.AddWithValue("@Password", userModel.Password);
                        cmd.Parameters.AddWithValue("@IsStudent", userModel.IsStudent);
                        if (cmd.ExecuteNonQuery() >= 1)
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
        private bool IsAlreadyRegistered(RegistrationModel registrationModel)
        {
            SqlDataReader sdr;
            using (SqlConnection connection = new SqlConnection(StringLiterals._connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(StringLiterals._alreadyUserRegisteredQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailAddress", registrationModel.EmailAddress);
                    sdr = command.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}