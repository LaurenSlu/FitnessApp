using ApplicationModels.FitnessApp.Models;
using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        FitnessClassEditView FindById(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClassView>>GetList();
        Task Save(FitnessClassEditView fitnessClass);
        void Delete(int id);
        FitnessClassEditView Create();
    }
}
