using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelance.Web.Models;
using PagedList.Mvc;
using PagedList;

using Freelance.Provider.Interfaces;
using Freelance.Provider;
using Freelance.Provider.EntityModels;
using Freelance.Extensions;

namespace Freelance.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        public ICategoryProvider Service { get; set; }

        public CategoryController()
        {
            Service = new ProviderFactory().CategoryProvider;
        }
        // GET: Category
        public ActionResult Index(int? page)
        {
            var list = Service.GetList().SetFilterOptions().SetSortOptions().SetPageOptions().Select(model=>new CategoryViewModel {
                CategoryId = model.Id,
                DescriptionCategory = model.DescriptionCategory,
                NameCategory = model.NameCategory

            });

            
            return View(list.ToPagedList(1,10));
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
            //Use mapping  !! delete this 
            var category = new Category {

                DescriptionCategory = model.DescriptionCategory,
                NameCategory = model.NameCategory
            };
            //
            try
            {
                if (ModelState.IsValid)
                {
                    Service.Create(category);
                    return RedirectToAction("Index");
                }

                return View(model);

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
