﻿using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using FitnessApp.Models.ApplicationViewModels;
using AutoMapper;
using System.Threading.Tasks;
using System;

namespace FitnessApp.Logic
{
    public class RegistrationRecordLogic : IRegistrationRecordLogic
    {
        private readonly IRegistrationRecordRepository _registrationRecordRepository;
        private readonly IFitnessClassRepository _fitnessClassRepository;

        public RegistrationRecordLogic(
            IRegistrationRecordRepository registrationRecordRepository,
            IFitnessClassRepository fitnessClassRepository)
        {
            _registrationRecordRepository = registrationRecordRepository;
            _fitnessClassRepository = fitnessClassRepository;
        }

        public RegistrationRecordView Get(int id)
        {
            var registrationRecord = _registrationRecordRepository.FindById(id);
            return Mapper.Map<RegistrationRecordView>(registrationRecord);
        }

        public async Task<List<RegistrationRecordView>> GetList()
        {
            var registrationRecords = await _registrationRecordRepository.All();

            if (registrationRecords == null || !registrationRecords.Any())
            {
                return Enumerable.Empty<RegistrationRecordView>().ToList();
            }
            return Mapper.Map<List<RegistrationRecordView>>(registrationRecords); ;
        }
        public async Task<List<FitnessClassRegistrationView>> FindByUserName(string userName)
        {
            var registrationRecords = await _registrationRecordRepository.FindByUserName(userName);
            var fitnessClassRegistration =
                await _fitnessClassRepository.RegistrationsByUserName(userName);

            if (fitnessClassRegistration == null || registrationRecords == null)
            {
                return Enumerable.Empty<FitnessClassRegistrationView>().ToList();

            }
            return MapRegistrationsToFitnessClassRegistrationView(
                fitnessClassRegistration,
                registrationRecords
            );
        }

        public async Task Save(RegistrationRecordView registrationRecordView)
        {
            var registrationRecord = Mapper.Map<RegistrationRecord>(registrationRecordView);
            await _registrationRecordRepository.Insert(registrationRecord);
        }

        public async Task SaveRange(int[] fitnessClassIds, string userName)
        {
            List<RegistrationRecord> registrationRecords = new List<RegistrationRecord>();
            foreach (var fitnessClassId in fitnessClassIds)
            {
                if (_fitnessClassRepository.UpdateCapacity(fitnessClassId))
                {
                    registrationRecords.Add(new RegistrationRecord
                    {
                        Created = DateTime.Now,
                        Email = userName,
                        FitnessClass_Id = fitnessClassId,
                        UserName = userName,
                        WaitListed = false
                    });
                }
            }

            if (registrationRecords.Count() > 0)
            {
                await _registrationRecordRepository.InsertRange(registrationRecords);
            }
        }

        public void Delete(int id)
        {
            _registrationRecordRepository.Delete(id);
        }

        public void DeleteRange(int[] ids)
        {
            _registrationRecordRepository.DeleteRange(ids);
        }

        private List<FitnessClassRegistrationView> MapRegistrationsToFitnessClassRegistrationView(
            List<FitnessClass> fitnessClassRegistration,
            List<RegistrationRecord> registrationRecords
        )
        {
            List<FitnessClassRegistrationView> registrationsListView =
                new List<FitnessClassRegistrationView>();

            foreach (var registration in registrationRecords)
            {
                var fitnessClass = FindFitnessClass(
                    fitnessClassRegistration,
                    registration.FitnessClass_Id
                );

                registrationsListView.Add(new FitnessClassRegistrationView
                {
                    DateOfClass = fitnessClass.DateOfClass,
                    StartTime = fitnessClass.StartTime,
                    EndTime = fitnessClass.EndTime,
                    FitnessClassTypeName = fitnessClass.FitnessClassType.Name,
                    InstructorName = fitnessClass.Instructor.Name,
                    LocationName = fitnessClass.Location.Name,
                    FitnessClass_Id = registration.FitnessClass_Id,
                    RegistrationRecord_Id = registration.Id,
                    WaitListed = registration.WaitListed
                });
            }

            return registrationsListView;
        }

        private FitnessClass FindFitnessClass(
            List<FitnessClass> fitnessClassRegistration,
            int fitnessClassId
        )
        {
            return fitnessClassRegistration.Find(f => f.Id == fitnessClassId);
        }
    }
}
