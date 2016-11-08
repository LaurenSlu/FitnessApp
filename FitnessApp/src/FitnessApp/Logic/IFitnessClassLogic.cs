using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        Task<FitnessClass> FindById(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClass>>GetList();
        Task Save(FitnessClass fitnessClass);
        void Delete(int id);
    }
}
