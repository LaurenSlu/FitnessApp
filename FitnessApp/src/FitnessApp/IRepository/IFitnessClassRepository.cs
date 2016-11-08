using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Core;
using System.Collections.Generic;

namespace FitnessApp.IRepository
{
    public interface IFitnessClassRepository
    {
        Task<List<FitnessClass>> All();
        Task Insert(FitnessClass fitnessClass);
        void Delete(int id);
        Task<FitnessClass> FindById(int id);
        bool Find(int id);
    }
}
