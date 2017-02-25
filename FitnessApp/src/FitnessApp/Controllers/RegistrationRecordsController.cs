using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using Microsoft.AspNetCore.Authorization;
using FitnessApp.Logic;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class RegistrationRecordsController : Controller
    {
        private readonly IRegistrationRecordLogic _registrationRecordLogic;

        public RegistrationRecordsController(IRegistrationRecordLogic registrationRecordLogic)
        {
            _registrationRecordLogic = registrationRecordLogic;
        }

        // GET: RegistrationRecords
        public async Task<IActionResult> RegistrationIndex()
        {
            return View(await _registrationRecordLogic.FindByUserName(User.Identity.Name));
        }

        //POST: RegistrationRecords/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationIndex(string[] deleteSelected)
        {
            try
            {
                var registrationRecordIds = deleteSelected.Select(int.Parse).ToArray();
                _registrationRecordLogic.DeleteRange(registrationRecordIds, User.Identity.Name);
            }
            catch (DbUpdateConcurrencyException) // need to change this to be less specific
            {
                throw;
            }

            return View(await _registrationRecordLogic.FindByUserName(User.Identity.Name));
        }
    }

}
