using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;

namespace WAD_WorkAndTravel.Services
{
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRepositoryWrapper _repository;

        public RegistrationFormService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<RegistrationForm> GetAllRegistrationForms()
        {
            return _repository.RegistrationForm.FindAll().ToList();
        }

        public RegistrationForm GetRegistrationFormById(int id)
        {
            return _repository.RegistrationForm.FindByCondition(j => j.id == id).FirstOrDefault();
        }

        public void CreateRegistrationForm(RegistrationForm RegistrationForm)
        {
            _repository.RegistrationForm.Create(RegistrationForm);
            _repository.Save();
        }

        public void UpdateRegistrationForm(RegistrationForm RegistrationForm)
        {
            _repository.RegistrationForm.Update(RegistrationForm);
            _repository.Save();
        }

        public void DeleteRegistrationForm(RegistrationForm RegistrationForm)
        {
            _repository.RegistrationForm.Delete(RegistrationForm);
            _repository.Save();
        }
    }
}
