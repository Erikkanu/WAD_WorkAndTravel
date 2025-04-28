using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface IRegistrationFormService
    {
        IEnumerable<RegistrationForm> GetAllRegistrationForms();
        RegistrationForm GetRegistrationFormById(int id);
        void CreateRegistrationForm(RegistrationForm RegistrationForm);
        void UpdateRegistrationForm(RegistrationForm RegistrationForm);
        void DeleteRegistrationForm(RegistrationForm RegistrationForm);
    }
}
