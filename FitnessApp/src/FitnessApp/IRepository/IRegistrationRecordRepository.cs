using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.IRepository
{
    public interface IRegistrationRecordRepository
    {
        List<RegistrationRecord> All();
        Task Insert(RegistrationRecord registrationRecord);
        void Delete(int id);
        RegistrationRecord FindById(int id);
    }
}
