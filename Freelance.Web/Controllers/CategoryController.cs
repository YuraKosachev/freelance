using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelance.Web.Models;
namespace Freelance.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            //Delete this
            var list = new List<CategoryViewModel>();
            list.Add(new CategoryViewModel
            {
                CategoryId = Guid.NewGuid(),
                NameCategory = "сантехник",
                DescriptionCategory = "Описание сантехника"
            });
            list.Add(new CategoryViewModel
            {
                CategoryId = Guid.NewGuid(),
                NameCategory = "электрик",
                DescriptionCategory = "Описание электрика"
            });
            list.Add(new CategoryViewModel
            {
                CategoryId = Guid.NewGuid(),
                NameCategory = "столяр",
                DescriptionCategory = "Описание столяра"
            });
            //
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
