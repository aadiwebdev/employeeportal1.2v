namespace Domain
{
    public interface IRegisterUser:IUserLogin
    {
         string FirstName { get; set; }
         string LastName { get; set; }
         string ConfirmPassword { get; set; }
         string IsStudent { get; set; }
    }

}