using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassTypeView FindById(int id);
        List<FitnessClassTypeView> GetList();
        Task Save(FitnessClassTypeView fitnessClassType);
        void Delete(int id);
    }
}
