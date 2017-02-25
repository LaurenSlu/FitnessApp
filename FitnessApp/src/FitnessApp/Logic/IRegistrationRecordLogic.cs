using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IRegistrationRecordLogic
    {
        RegistrationRecordView Get(int id);
        Task<List<RegistrationRecordView>> GetList();
        Task<List<FitnessClassRegistrationView>> FindByUserName(string userName);
        Task Save(RegistrationRecordView registrationRecord);
        Task SaveRange(int[] fitnessClassIds, string userName);
        void Delete(int id);
        void DeleteRange(int[] registrationRecordIds, string userName);
    }
}
