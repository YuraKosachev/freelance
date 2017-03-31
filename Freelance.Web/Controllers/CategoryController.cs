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
using Freelance.FreelanceException;

namespace Freelance.Web.Controllers
{

    public class CategoryControllerMapperProfile : Profile
    {
        public CategoryControllerMapperProfile()
        {
            CreateMap<CategoryServiceModel,CategoryViewModel>()
                .ForMember(item => item.CategoryId, exp => exp.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(item => item.Id, exp => exp.MapFrom(src => src.CategoryId));

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
            try
            {
                var category = Service.GetItem(id);
                return View(Mapper.Map<CategoryViewModel>(category));
            }
            catch (ItemNotFoundException e)
            {
                return View();
            }
            catch
            {
                return View();
            }
            
               
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
        public ActionResult Delete(Guid id)
        {
            try
            {
                // TODO: Add delete logic here
                var item = Mapper.Map<CategoryViewModel>(Service.GetItem(id));
                return View(item);
            }
            catch (ItemNotFoundException e)
            {
                return View();
            }
            catch
            {
                return View();
            }
            
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoryViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                Service.Delete(model.CategoryId);
                return RedirectToAction("Index");
            }
            catch (ItemNotFoundException e)
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
