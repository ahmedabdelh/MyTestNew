using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTestNew.Data;
using MyTestNew.Models;

namespace MyTestNew.Controllers
{
    public class CompanyController : Controller
    {
        private readonly MyTestContext _context;

        public CompanyController(MyTestContext Context)
        {
            _context = Context;
        }

        public IActionResult Index()
        {
            return View(_context.Companies.OrderBy(a => a.Name).ToList());

        }

        /// <summary>
        /// /Create Company
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
       
            ViewBag.Emps = _context.emps.OrderBy(a => a.Name).ToList();
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company model)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View(model);
        }

        //////
        ///

        /// <summary>
        /// /Update Company
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int ?id)
        {
            ViewBag.Emps = _context.emps.OrderBy(a => a.Name).ToList();
            return View(_context.Companies.FirstOrDefault(a=>a.Id==id));

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company model)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// /Delete Company
        /// </summary>
        /// <returns></returns>
        public IActionResult Delate(int? id)
        {
            return View(_context.Companies.FirstOrDefault(a => a.Id == id));


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delate(Company model)
        {
            if (model != null)
            {
                _context.Companies.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}
