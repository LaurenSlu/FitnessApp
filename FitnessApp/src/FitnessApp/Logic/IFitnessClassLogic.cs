﻿using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassLogic
    {
        FitnessClassView FindById(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClassView>>GetList();
        Task Save(FitnessClassView fitnessClass);
        void Delete(int id);
        FitnessClassView Create();
    }
}
