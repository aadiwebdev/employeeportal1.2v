using Business.Factory;
using Domain;
using Domain.Enums;
using Domain.Interfaces;
using Domain.StringLiterals;
using System;
using System.Collections.Generic;
using System.Security;


namespace ConApp
{
    class Menu
    {
        private IUserBusiness _userBusiness;
        private IAuthenticationBusiness _authBusiness;
        private Model _model;
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _password;
        private string _confirmPassword;
        private string _isStudent;
        public Menu()
        {
            _authBusiness = BusinessFactory.GetAuthentication();
            _userBusiness = BusinessFactory.GetUserBusiness();
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
            Console.Write("\nEnter Email address.. :-");
            _emailAddress = Console.ReadLine();
            Console.Write("\nEnter Password.. :- ");
            _password = GetPassword().ToPlainString();
            _model = ModelFactory.GetModel(ModelSelection.Login);
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
            Console.Write("\nEnter First Name:- ");
            _firstName = Console.ReadLine();
            Console.Write("\nEnter Last Name:- ");
            _lastName = Console.ReadLine();
            Console.Write("\nEnter Email Address:-");
            _emailAddress = Console.ReadLine();
            Console.Write("\nEnter Password:-");
            _password = GetPassword().ToPlainString();
            Console.Write("\nEnter ConfirmPassword:- ");
            _confirmPassword = GetPassword().ToPlainString();
            Console.Write("\nAre you a Student or Not (yes|no) :-");
            _isStudent = Console.ReadLine().ToLower();
            _model = ModelFactory.GetModel(ModelSelection.Register);
            _model.FirstName = _firstName;
            _model.LastName = _lastName;
            _model.EmailAddress = _emailAddress;
            _model.Password = _password;
            _model.ConfirmPassword = _confirmPassword;
            _model.IsStudent = _isStudent;
            return _model;
        }
        /// <summary>
        /// It is to process the request given by the user based on the choice selected by him.
        /// </summary>
        /// <param name="choice"></param>
        public void ProcessRequest()
        {
            string message = string.Empty;
            while (true)
            {
                Console.WriteLine("\nWelcome to GGK Technologies!!!!!!!!!!");
                Console.WriteLine("\n1.User Login\n");
                Console.WriteLine("\n2.User Registration\n");
                Console.WriteLine("\n3.Get User Details\n");
                Console.Write("\nEnter Your Choice:- ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (int)UserSelectionChoice.Login:
                        _model = ReadLoginData();
                        message = ValidateLogin(_model);
                        if (!message.Equals(StringLiterals._success))
                        {
                            Console.WriteLine("\n\n"+message);
                        }
                        else
                        {
                            Console.WriteLine("\n\n"+StringLiterals._loginSuccess);
                        }
                        break;
                    case (int)UserSelectionChoice.Register:

                        _model = ReadRegisterData();
                        message = RegisterUser(_model);
                        if (!message.Equals(StringLiterals._success))
                        {
                            Console.WriteLine("\n\n"+message);
                        }
                        else
                        {
                            Console.WriteLine("\n\n"+StringLiterals._registrationSuccess);
                        }
                        break;

                    case (int)UserSelectionChoice.GetUserDetails:

                        Console.Write("\nEnter Choice 1 =>Users 2=>Others 3=>All:- ");
                        int userChoice = int.Parse(Console.ReadLine());
                        List<Model> usersList = DisplayUsers((UserRoleChoice)userChoice);
                        foreach (var users in usersList)
                        {
                            Console.WriteLine("\nThe employee name is :" + users.FirstName + users.LastName);
                            Console.WriteLine("\nThe Employee email address is :" + users.EmailAddress);
                        }
                        break;
                }
            }
        }

    }
}
