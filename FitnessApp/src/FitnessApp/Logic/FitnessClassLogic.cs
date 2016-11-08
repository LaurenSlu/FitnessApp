using ApplicationModels.FitnessApp.Models;
using FitnessApp.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;

        public FitnessClassLogic(IFitnessClassRepository fitnessClassRepository)
        {
            _fitnessClassRepository = fitnessClassRepository;
        }

        public async Task<FitnessClass> FindById(int id)
        {
            return await _fitnessClassRepository.FindById(id);
        }

        public async Task<List<FitnessClass>> GetList()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClass>().ToList();
            }

            return fitnessClasses;
        }

        public async Task Save(FitnessClass fitnessClass)
        {
            await _fitnessClassRepository.Insert(fitnessClass);
        }

        public void Delete(int id)
        {
            _fitnessClassRepository.Delete(id);
        }

        public bool FitnessClassExists(int id)
        {
            return _fitnessClassRepository.Find(id);
        }
    }
}
