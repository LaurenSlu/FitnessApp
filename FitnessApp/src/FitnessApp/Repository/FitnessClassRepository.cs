using FitnessApp.IRepository;
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
            return await _context.FitnessClass
                .Include(f => f.FitnessClassType)
                .Include(t => t.Instructor)
                .Include(l => l.Location).ToListAsync();
        }

        public void Delete(int id)
        {
            var fitnessClass = FindById(id);
            _context.Remove(fitnessClass);
            _context.SaveChanges();
        }

        public FitnessClass FindById(int id)
        {
            return _context.FitnessClass
                .Include(f => f.FitnessClassType)
                .Include(t => t.Instructor)
                .Include(l => l.Location)
                .SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(FitnessClass fitnessClass)
        {
            if (fitnessClass.Id > 0) {
                fitnessClass.Updated = DateTime.Now;
                _context.Update(fitnessClass); 
            }
            else {
                fitnessClass.Created = DateTime.Now;
                _context.Add(fitnessClass);
            }
            await _context.SaveChangesAsync();
        }

        public bool FitnessClassExists(int id) {
            return _context.FitnessClass.Any(e => e.Id == id);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
