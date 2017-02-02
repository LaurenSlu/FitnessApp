using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Repository
{
    public class RegistrationRecordRepository : IRegistrationRecordRepository
    {
        private FitnessAppDbContext _context;
        public RegistrationRecordRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public List<RegistrationRecord> All()
        {
            return _context.RegistrationRecord.Include(f => f.FitnessClass).ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RegistrationRecord FindById(int id)
        {
            return _context.RegistrationRecord
                .Include(f => f.FitnessClass)
                .SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(RegistrationRecord registrationRecord)
        {
            if (registrationRecord.Id > 0)
            {
                _context.Update(registrationRecord);
            } else
            {
                _context.Add(registrationRecord);
            }
            await _context.SaveChangesAsync();
        }
    }
}
