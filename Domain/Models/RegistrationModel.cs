using Domain.Interfaces;

namespace Domain.Models
{
    public class RegistrationModel:Model
    {
         public RegistrationModel()
        {
            this.SetMapping(x => x.FirstName = this.FirstName, x => x.LastName = this.LastName,
                x => x.EmailAddress = this.EmailAddress, x => x.Password = this.Password,x => x.IsStudent = this.IsStudent);
        }
    }
}
