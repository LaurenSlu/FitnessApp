using ApplicationModels.FitnessApp.Models;
using FitnessApp.IRepository;
using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

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

        public FitnessClassEditView Create()
        {
            return new FitnessClassEditView
            {
                FitnessClassTypes = GetFitnessClassTypes(),
                Locations = GetLocations(),
                Instructors = GetInstructors()
            };
        }

        public FitnessClassEditView FindById(int id)
        {
            var fitnessClass = _fitnessClassRepository.FindById(id);
            return MapToEditView(fitnessClass) ?? new FitnessClassEditView { };
        }

        public async Task<List<FitnessClassView>> GetList()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassView>().ToList();
            }

            return MapToView(fitnessClasses);
        }

        public async Task Save(FitnessClassEditView fitnessClassEditView)
        {
            var fitnessClass = MapToModel(fitnessClassEditView);
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

        private FitnessClass MapToModel(FitnessClassEditView fitnessClassEditView)
        {
            var fitnessClass = new FitnessClass
            {
                Id = fitnessClassEditView.Id,
                Capacity = fitnessClassEditView.Capacity,
                DateOfClass = fitnessClassEditView.DateOfClass,
                StartTime = fitnessClassEditView.StartTime,
                EndTime = fitnessClassEditView.EndTime,
                FitnessClassType_Id = fitnessClassEditView.FitnessClassType.Id,
                Instructors_Id = fitnessClassEditView.Instructor.Id,
                Location_Id = fitnessClassEditView.Location.Id,
                Status = fitnessClassEditView.Status
            };

            return fitnessClass;
        }

        private List<FitnessClassView> MapToView(List<FitnessClass> fitnessClasses)
        {
            var fitnessClassList = fitnessClasses.Select(x => new FitnessClassView()
            {
                Id = x.Id,
                Capacity = x.Capacity,
                DateOfClass = x.DateOfClass,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status,
                FitnessClassType = x.FitnessClassType,
                Instructor = x.Instructor,
                Location = x.Location
            });

            return fitnessClassList.ToList();
        }

        //we need to implement a view model for the other tables and replace these ones
        private FitnessClassEditView MapToEditView(FitnessClass fitnessClass)
        {
            var fitnessClassEditView = new FitnessClassEditView
            {
                Id = fitnessClass.Id,
                Capacity = fitnessClass.Capacity,
                DateOfClass = fitnessClass.DateOfClass,
                StartTime = fitnessClass.StartTime,
                EndTime = fitnessClass.EndTime,
                FitnessClassType = fitnessClass.FitnessClassType,
                Instructor = fitnessClass.Instructor,
                Location = fitnessClass.Location,
                Status = fitnessClass.Status,
                FitnessClassTypes = GetFitnessClassTypes(),
                Instructors = GetInstructors(),
                Locations = GetLocations()
            };

            return fitnessClassEditView;
        }

        private ICollection<SelectListItem> GetLocations()
        {
            var locations = _locationLogic.GetList();
            var locationSelectList = locations.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(locationSelectList);
        }

        private ICollection<SelectListItem> GetInstructors()
        {
            var instructors = _instructorLogic.GetList();
            var instructorSelectList = instructors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(instructorSelectList);
        }

        private ICollection<SelectListItem> GetFitnessClassTypes()
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
