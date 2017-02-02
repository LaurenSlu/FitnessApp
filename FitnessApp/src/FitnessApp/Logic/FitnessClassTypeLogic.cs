using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public class FitnessClassTypeLogic : IFitnessClassTypeLogic
    {
        private readonly IFitnessClassTypeRepository _fitnessClassTypeRepository;

        public FitnessClassTypeLogic(IFitnessClassTypeRepository fitnessClassTypeRepository)
        {
            _fitnessClassTypeRepository = fitnessClassTypeRepository;
        }

        public FitnessClassType FindById(int id)
        {
            return _fitnessClassTypeRepository.FindById(id);
        }

        public List<FitnessClassType> GetList()
        {
            var fitnessClassesType = _fitnessClassTypeRepository.All();

            if (fitnessClassesType == null || !fitnessClassesType.Any())
            {
                return Enumerable.Empty<FitnessClassType> ().ToList();
            }
            return fitnessClassesType;
        }

        public async Task Save(FitnessClassType fitnessClassType)
        {
            await _fitnessClassTypeRepository.Insert(fitnessClassType);
        }

        public void Delete(int id)
        {
            _fitnessClassTypeRepository.Delete(id);
        }
    }
}
