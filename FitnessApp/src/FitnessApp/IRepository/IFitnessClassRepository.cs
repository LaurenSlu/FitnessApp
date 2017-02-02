using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;

namespace FitnessApp.IRepository
{
    public interface IFitnessClassRepository
    {
        Task<List<FitnessClass>> All();
        Task Insert(FitnessClass fitnessClass);
        void Delete(int id);
        FitnessClass FindById(int id);
        bool FitnessClassExists(int id);
    }
}
