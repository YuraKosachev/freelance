using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelance.Web.Models;
using PagedList.Mvc;
using PagedList;
using Freelance.Service;
using Freelance.Service.ServicesModel;
using Freelance.Service.Interfaces;
using AutoMapper;

namespace Freelance.Web.Controllers
{

    public class CategoryControllerMapperProfile : Profile
    {
        public CategoryControllerMapperProfile()
        {
            CreateMap<CategoryServiceModel,CategoryViewModel>().ReverseMap();

        }

    }

    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        public ICategoryService Service { get; set; }

        public CategoryController()
        {
            Service = new ServiceFactory().CategoryService;
        }
        // GET: Category
        public ActionResult Index(int? page)
        {
            var list = Service.GetList().Select(model => Mapper.Map<CategoryViewModel>(model));
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            try
            {
               Service.Create(Mapper.Map<CategoryServiceModel>(model));
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
            var category = Service.GetItem(id);

            return View(Mapper.Map<CategoryViewModel>(category));
               
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                    Service.Update(Mapper.Map<CategoryServiceModel>(model));
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
