using Business;
using Domain;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Domain.StringLiterals;
using System;
using System.Collections.Generic;
using System.Security;


namespace ConApp
{
    class Menu
    {
        private UserBusiness _userBusiness;
        private AuthenticationBusiness _authBusiness;
        private Model _model;
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _password;
        private string _confirmPassword;
        private string _isStudent;
        public Menu()
        {
            _authBusiness = new AuthenticationBusiness();
            _userBusiness = new UserBusiness();
        }
        

        /// <summary>
        /// For displaying user details
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<Model> DisplayUsers(UserRoleChoice userRoleChoice)
        {
            return _userBusiness.GetUserDetails(userRoleChoice);
        }
        /// <summary>
        /// It is used to register user
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(Model registrationModel)
        {
            if (_authBusiness.RegisterUser(registrationModel).Equals(StringLiterals._success))
            {
                return StringLiterals._success;
            }
            return _authBusiness.RegisterUser(registrationModel);
        }
        /// <summary>
        ///It is used to validate the user credentails
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(Model loginModel)
        {
            if (_authBusiness.ValidateLogin(loginModel).Equals(StringLiterals._success))
            {
                return StringLiterals._success;
            }
            return _authBusiness.ValidateLogin(loginModel);
        }
        /// <summary>
        /// It is used to mask the password at console
        /// </summary>
        /// <returns></returns>
        public SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
        /// <summary>
        /// It represents getting login related input from user
        /// </summary>
        /// <returns></returns>
        public Model ReadLoginData()
        {
            Console.WriteLine("\nEnter Email address..\n");
            _emailAddress = Console.ReadLine();
            Console.WriteLine("\nEnter Password..\n");
            _password = GetPassword().ToPlainString();
            _model = ModelFactory.getModel(ModelSelection.Login);
            _model.EmailAddress = _emailAddress;
            _model.Password = _password;
            return _model;
        }
        /// <summary>
        /// It represents getting regsitration related input from user.
        /// </summary>
        /// <returns></returns>
        public Model ReadRegisterData()
        {
            Console.WriteLine("\nEnter First Name");
            _firstName = Console.ReadLine();
            Console.WriteLine("\nEnter Last Name");
            _lastName = Console.ReadLine();
            Console.WriteLine("\nEnter Email Address");
            _emailAddress = Console.ReadLine();
            Console.WriteLine("\nEnter Password");
            _password = GetPassword().ToPlainString();
            Console.WriteLine("\nEnter ConfirmPassword");
            _confirmPassword = GetPassword().ToPlainString();
            Console.WriteLine("\nAre you a Student or Not.");
            _isStudent = Console.ReadLine().ToLower();
            _model = ModelFactory.getModel(ModelSelection.Register);
            _model.FirstName = _firstName;
            _model.LastName = _lastName;
            _model.EmailAddress = _emailAddress;
            _model.Password = _password;
            _model.ConfirmPassword = _confirmPassword;
            _model.IsStudent = _isStudent;
            return _model;
        }

    }
}
