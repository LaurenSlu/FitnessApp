using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitnessApp.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public Instructor FindById(int id)
        {
            return _instructorRepository.FindById(id);
        }

        public List<Instructor> GetList()
        {
            var instructors = _instructorRepository.All();

            if (instructors == null || !instructors.Any())
            {
                return Enumerable.Empty<Instructor>().ToList();
            }

            return instructors;
        }

        public async Task Save(Instructor instructor)
        {
            await _instructorRepository.Insert(instructor);
        }

        public void Delete(int id)
        {
            _instructorRepository.Delete(id);
        }
    }
}
