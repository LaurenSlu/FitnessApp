using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IInstructorLogic
    {
        Instructor FindById(int id);
        List<Instructor> GetList();
        Task Save(Instructor instructor);
        void Delete(int id);
    }
}
