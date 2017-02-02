using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface ILocationLogic
    {
        Location Get(int id);
        List<Location> GetList();
        Task Save(Location location);
        void Delete(int id);
    }
}
