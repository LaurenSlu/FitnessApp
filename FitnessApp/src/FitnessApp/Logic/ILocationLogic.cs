using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface ILocationLogic
    {
        LocationView Get(int id);
        List<LocationView> GetList();
        Task Save(LocationView location);
        void Delete(int id);
    }
}
