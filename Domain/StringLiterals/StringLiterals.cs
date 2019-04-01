namespace Domain.StringLiterals
{
    public static class StringLiterals
    {
        public static string _emptyEmail = "Please Enter Your Email.....";
        public static string _success = "successful";
        public static string _invalidName = "Only characters are allowed.."; 
        public static string _invalidEmail = "Invalid Email Address";
        public static string _invalidUpperCasePassword = "Password should contain At least one upper case letter";
        public static string _invalidLowerCasePassword = "Password should contain At least one lower case letter";
        public static string _invalidCharCountPassword = "Password should not be less than or greater than 12 characters";
        public static string _invalidNumericPassword = "Password should contain At least one numeric value";
        public static string _invalidSpecialSymbolPassword = "Password should contain At least one special case characters";
        public static string _loginSuccess = "Login successfull!!";
        public static string _loginFailed = "Invalid user credentials";
        public static string _registrationSuccess = "Registration successfull!!";
        public static string _registrationFailed = "User already Exists!!";
        public static string _yes = "yes";
        public static string _no = "no";
        public static string _validateEmailRegEx = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                                   + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                                   + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                                   + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                                   + @"[a-zA-Z]{2,}))$";
        public static string _validateNumber = @"[0-9]+";
        public static string _validateUpperCase = @"[A-Z]+";
        public static string _validateMinMaxChars = @".{8,15}";
        public static string _validateLowerCase = @"[a-z]+";
        public static string _validateSpecialSymbols = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";


    }
}
