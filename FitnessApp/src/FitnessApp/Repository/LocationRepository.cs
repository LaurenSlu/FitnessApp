using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FitnessApp.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private FitnessAppDbContext _context;
        public LocationRepository(FitnessAppDbContext context)
        {
            _context = context;
        }
        public List<Location> All()
        {
            return _context.Location.ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Location FindById(int id)
        {
            return _context.Location.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(Location location)
        {
            if (location.Id > 0)
            {
                _context.Update(location);
            } else
            {
                _context.Add(location);
            }
            await _context.SaveChangesAsync();
        }
    }
}
