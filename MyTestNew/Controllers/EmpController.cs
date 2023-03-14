using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTestNew.Data;
using MyTestNew.Models;

namespace MyTestNew.Controllers
{
    public class EmpController : Controller
    {
        private readonly MyTestContext _context;

        public EmpController(MyTestContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View(_context.emps.OrderBy(a=>a.Name).ToList());
        }


        /// <summary>
        /// /Create Emp
        /// </summary>
        /// <returns></returns>
        public IActionResult  Create ()
        {
          
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Emp model)
        {
            if (ModelState.IsValid)
            {
                _context.emps.Add(model);
                _context.SaveChanges(); 
                return RedirectToAction("Index");

            }
            return View(model);
        }


        /// <summary>
        /// /update Emp
        /// </summary>
        /// <returns></returns>

        public IActionResult Edit(Guid ? id)
        {
            return View(_context.emps.FirstOrDefault(a=>a.Id==id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Emp model)
        {
            if (ModelState.IsValid)
            {
                _context.emps.Update(model);
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
            return View(_context.emps.FirstOrDefault(a=>a.Id==id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Emp model)
        {
            if (model!=null)
            {
                _context.emps.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }

    }
}
