using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Logic;
using ApplicationModels.FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FitnessApp.Controllers
{
    public class FitnessClassesController : Controller
    {
        private readonly IFitnessClassLogic _fitnessClassLogic;

        public FitnessClassesController(IFitnessClassLogic fitnessClassLogic)
        {
            _fitnessClassLogic = fitnessClassLogic;    
        }

        // GET: FitnessClasses
        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassLogic.GetList());
        }

        // GET: FitnessClasses/Details/5
        public IActionResult Details(int id)
        {
            var fitnessClass = _fitnessClassLogic.FindById(id);
            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Capacity,Created,DateOfClass,EndTime,StartTime,Status,Updated")] FitnessClass fitnessClass)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(fitnessClass);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(fitnessClass);
        //}

        // GET: FitnessClasses/Edit/5
        public IActionResult Edit(int id)
        {
            var fitnessClass = _fitnessClassLogic.FindById(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Capacity,Created,DateOfClass,EndTime,StartTime,Status,Updated")] FitnessClass fitnessClass)
        {
            if (id != fitnessClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fitnessClassLogic.Save(fitnessClass);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_fitnessClassLogic.FitnessClassExists(fitnessClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(fitnessClass);
        }

        //    // GET: FitnessClasses/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var fitnessClass = await _context.FitnessClass.SingleOrDefaultAsync(m => m.Id == id);
        //        if (fitnessClass == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(fitnessClass);
        //    }

        //    // POST: FitnessClasses/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var fitnessClass = await _context.FitnessClass.SingleOrDefaultAsync(m => m.Id == id);
        //        _context.FitnessClass.Remove(fitnessClass);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

    }
}
