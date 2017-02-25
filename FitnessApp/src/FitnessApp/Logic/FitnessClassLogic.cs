using ApplicationModels.FitnessApp.Models;
using FitnessApp.IRepository;
using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using AutoMapper;

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;
        private readonly IInstructorLogic _instructorLogic;
        private readonly IFitnessClassTypeLogic _fitnessClassTypeLogic;
        private readonly ILocationLogic _locationLogic;

        public FitnessClassLogic(
            IFitnessClassRepository fitnessClassRepository,
            IInstructorLogic instructorLogic,
            IFitnessClassTypeLogic fitnessClassTypeLogic,
            ILocationLogic locationLogic
        )
        {
            _fitnessClassRepository = fitnessClassRepository;
            _instructorLogic = instructorLogic;
            _fitnessClassTypeLogic = fitnessClassTypeLogic;
            _locationLogic = locationLogic;
        }

        public FitnessClassView Create()
        {
            return new FitnessClassView
            {
                FitnessClassTypes = GetFitnessClassTypes(),
                Locations = GetLocations(),
                Instructors = GetInstructors()
            };
        }

        public FitnessClassView FindById(int id)
        {
            var fitnessClass = _fitnessClassRepository.FindById(id);
            var fitnessClassView = Mapper.Map<FitnessClassView>(fitnessClass);
            fitnessClassView.FitnessClassTypes = GetFitnessClassTypes();
            fitnessClassView.Instructors = GetInstructors();
            fitnessClassView.Locations = GetLocations();
            return fitnessClassView;
        }

        public async Task<List<FitnessClassView>> GetList()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassView>().ToList();
            }
            return Mapper.Map<List<FitnessClassView>>(fitnessClasses);
        }

        public async Task<List<FitnessClassSignUpView>> GetAvailableClasses(string userName)
        {
            var fitnessClasses = await _fitnessClassRepository.AllAvailable(userName);

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassSignUpView>().ToList();
            }
            return Mapper.Map<List<FitnessClassSignUpView>>(fitnessClasses);
        }

        public async Task Save(FitnessClassView fitnessClassView)
        {
            var fitnessClass = Mapper.Map<FitnessClass>(fitnessClassView);
            await _fitnessClassRepository.Insert(fitnessClass);
        }

        public void Delete(int id)
        {
            _fitnessClassRepository.Delete(id);
        }

        public bool FitnessClassExists(int id)
        {
            return _fitnessClassRepository.FitnessClassExists(id);
        }

        public ICollection<SelectListItem> GetLocations()
        {
            var locations = _locationLogic.GetList();
            var locationSelectList = locations.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(locationSelectList);
        }

        public ICollection<SelectListItem> GetInstructors()
        {
            var instructors = _instructorLogic.GetList();
            var instructorSelectList = instructors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(instructorSelectList);
        }

        public ICollection<SelectListItem> GetFitnessClassTypes()
        {
            var fitnessClassTypes = _fitnessClassTypeLogic.GetList();
            var fitnessClassTypesSelectList = fitnessClassTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(fitnessClassTypesSelectList);
        }

        private SelectListItem AddDefaultSelectItem()
        {
            return new SelectListItem
            {
                Value = "",
                Text = "Please Select an Item"
            };
        }

        private ICollection<SelectListItem> BuildSelectListItems(IEnumerable<SelectListItem> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(AddDefaultSelectItem());
            selectList.AddRange(list);
            return selectList;
        }
    }
}
