using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using FitnessApp.Models.ApplicationViewModels;
using AutoMapper;

namespace FitnessApp.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public InstructorView FindById(int id)
        {
            var instructor = _instructorRepository.FindById(id);
            return Mapper.Map<InstructorView>(instructor);
        }

        public List<InstructorView> GetList()
        {
            var instructors = _instructorRepository.All();

            if (instructors == null || !instructors.Any())
            {
                return Enumerable.Empty<InstructorView>().ToList();
            }

            return Mapper.Map<List<InstructorView>>(instructors); ;
        }

        public async Task Save(InstructorView instructorView)
        {
            var instructor = Mapper.Map<Instructor>(instructorView);
            await _instructorRepository.Insert(instructor);
        }

        public void Delete(int id)
        {
            _instructorRepository.Delete(id);
        }
    }
}
