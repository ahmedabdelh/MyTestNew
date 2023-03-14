using Microsoft.AspNetCore.Mvc;
using MyTestNew.Data;
using MyTestNew.Models;

namespace MyTestNew.Controllers
{
    public class WorkMController : Controller
    {
        private readonly MyTestContext _context;

        public WorkMController(MyTestContext context)
        {
             _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.workMs.ToList());
        }

        /// <summary>
        /// /Create Emp
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
     
            ViewBag.Emps = _context.emps.OrderBy(a => a.Name).ToList();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkM model)
        {
            if (ModelState.IsValid)
            {
                _context.workMs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }


        /// <summary>
        /// /update Emp
        /// </summary>
        /// <returns></returns>

        public IActionResult Edit(Guid? id)
        {
            ViewBag.Emps = _context.emps.OrderBy(a => a.Name).ToList();
            return View(_context.workMs.FirstOrDefault(a => a.Id == id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkM model)
        {
            if (ModelState.IsValid)
            {
                _context.workMs.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }



        /// <summary>
        /// /Delate Emp
        /// </summary>
        /// <returns></returns>

        public IActionResult Delete(Guid? id)
        {
            return View(_context.workMs.FirstOrDefault(a => a.Id == id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(WorkM model)
        {
            if (model != null)
            {
                _context.workMs.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}
