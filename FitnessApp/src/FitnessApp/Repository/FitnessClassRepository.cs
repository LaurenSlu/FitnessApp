using FitnessApp.IRepository;
using FitnessApp.Core;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FitnessApp.Repository
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private FitnessAppDbContext _context;
        public FitnessClassRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FitnessClass>> All()
        {
            return await _context.FitnessClass.Include(f => f.FitnessClassType)
                                            .Include(t => t.Instructor)
                                            .Include(l => l.Location).ToListAsync();
        }

        public void Delete(int id)
        {            
            throw new NotImplementedException();
        }

        public async Task<FitnessClass> FindById(int id)
        {
            return await _context.FitnessClass.Include(f => f.FitnessClassType)
                                            .Include(t => t.Instructor)
                                            .Include(l => l.Location)
                                            .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task Insert(FitnessClass fitnessClass)
        {
            if (fitnessClass.Id > 0) {
                _context.Update(fitnessClass); 
            }
            else {
                _context.Add(fitnessClass);
            }
            await _context.SaveChangesAsync();
        }

        public bool Find(int id) {
            return _context.FitnessClass.Any(e => e.Id == id);
        }
    }
}
