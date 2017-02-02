using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FitnessApp.Repository
{
    public class FitnessClassTypeRepository : IFitnessClassTypeRepository
    {
        private FitnessAppDbContext _context;
        public FitnessClassTypeRepository(FitnessAppDbContext context) 
        {
            _context = context;
        }

        public List<FitnessClassType> All()
        {
            return _context.FitnessClassType.ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FitnessClassType FindById(int id)
        {
            return _context.FitnessClassType.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(FitnessClassType fitnessClassType)
        {
            if (fitnessClassType.Id > 0)
            {
                _context.Update(fitnessClassType);
            }
            else
            {
                _context.Add(fitnessClassType);
            }
            await _context.SaveChangesAsync();
        }
    }
}
