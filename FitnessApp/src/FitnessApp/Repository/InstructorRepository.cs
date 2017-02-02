using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FitnessApp.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private FitnessAppDbContext _context;
        public InstructorRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public List<Instructor> All()
        {
            return _context.Instructor.ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Instructor FindById(int id)
        {
            return _context.Instructor.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(Instructor instructor)
        {
            if (instructor.Id > 0)
            {
                _context.Update(instructor);
            }
            else
            {
                _context.Add(instructor);
            }
            await _context.SaveChangesAsync();
        }
    }
}
