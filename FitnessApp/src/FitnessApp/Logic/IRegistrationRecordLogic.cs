using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public interface IRegistrationRecordLogic
    {
        RegistrationRecord Get(int id);
        List<RegistrationRecord> GetList();
        void Save(RegistrationRecord registrationRecord);
        void Delete(int id);
    }
}
