using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassType FindById(int id);
        List<FitnessClassType> GetList();
        Task Save(FitnessClassType fitnessClassType);
        void Delete(int id);
    }
}
