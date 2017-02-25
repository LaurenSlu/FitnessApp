using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        FitnessClassView FindById(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClassView>> GetList();
        Task<List<FitnessClassSignUpView>> GetAvailableClasses(string userName);
        Task Save(FitnessClassView fitnessClass);
        void Delete(int id);
        FitnessClassView Create();
        ICollection<SelectListItem> GetLocations();
        ICollection<SelectListItem> GetInstructors();
        ICollection<SelectListItem> GetFitnessClassTypes();
    }
}
