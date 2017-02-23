using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using FitnessApp.Models.ApplicationViewModels;
using AutoMapper;

namespace FitnessApp.Logic
{
    public class RegistrationRecordLogic : IRegistrationRecordLogic
    {
        private readonly IRegistrationRecordRepository _registrationRecordRepository;

        public RegistrationRecordLogic(IRegistrationRecordRepository registrationRecordRepository)
        {
            _registrationRecordRepository = registrationRecordRepository;
        }

        public RegistrationRecordView Get(int id)
        {
            var registrationRecord = _registrationRecordRepository.FindById(id);
            return Mapper.Map<RegistrationRecordView>(registrationRecord);
        }

        public List<RegistrationRecordView> GetList()
        {
            var registrationRecords = _registrationRecordRepository.All();

            if (registrationRecords == null || !registrationRecords.Any())
            {
                return Enumerable.Empty<RegistrationRecordView>().ToList();
            }

            return Mapper.Map<List<RegistrationRecordView>>(registrationRecords); ;
        }

        public void Save(RegistrationRecordView registrationRecordView)
        {
            var registrationRecord = Mapper.Map<RegistrationRecord>(registrationRecordView);
            _registrationRecordRepository.Insert(registrationRecord);
        }

        public void Delete(int id)
        {
            _registrationRecordRepository.Delete(id);
        }
    }
}
