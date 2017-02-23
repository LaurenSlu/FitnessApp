using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public interface IRegistrationRecordLogic
    {
        RegistrationRecordView Get(int id);
        List<RegistrationRecordView> GetList();
        void Save(RegistrationRecordView registrationRecord);
        void Delete(int id);
    }
}
