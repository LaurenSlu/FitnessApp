using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
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

        public async Task<List<RegistrationRecord>> All()
        {
            return await _context.RegistrationRecord.Include(f => f.FitnessClass).ToListAsync();
        }

        public async Task<List<RegistrationRecord>> FindByUserName(string userName)
        {
            return await _context.RegistrationRecord.Where(r => r.UserName == userName)
                .Include(r => r.FitnessClass).ToListAsync();
        }

        public async Task<List<RegistrationRecord>> FindByFitnessClassId(int fitnessClassId)
        {
            return await _context.RegistrationRecord.Where(r => r.FitnessClass_Id == fitnessClassId)
                .ToListAsync();
        }

        public void Delete(int id)
        {
            var registration = FindById(id);
            _context.Remove(registration);
            _context.SaveChanges();
        }

        public void DeleteRange(List<RegistrationRecord> recordsToDelete)
        {
            _context.RemoveRange(recordsToDelete);
            _context.SaveChanges();
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

        public async Task InsertRange(List<RegistrationRecord> registrationRecords)
        {
            var updateRegistrations = registrationRecords.FindAll(r => r.Id > 0);
            var addNewRegistrations = registrationRecords.FindAll(r => r.Id == 0);

            if (addNewRegistrations != null && addNewRegistrations.Count() != 0)
            {
                _context.AddRange(addNewRegistrations);
            }

            if (updateRegistrations != null && updateRegistrations.Count() != 0)
            {
                _context.UpdateRange(updateRegistrations);
            }
            await _context.SaveChangesAsync();
        }
    }
}
