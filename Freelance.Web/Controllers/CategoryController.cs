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
using Microsoft.Practices.Unity;

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
        private ICategoryService Service { get; set; }
        [InjectionConstructor]
        public CategoryController(ICategoryService service)
        {
            Service = service;
        }



        // GET: Category
        public ActionResult Index(IndexState state)
        {
            var listSetting = Service.GetList();
            //sorting
            if(string.IsNullOrEmpty(state.SortProperty))
                listSetting.SortPage("NameCategory",ascending:true);
            else
                listSetting.SortPage(state.SortProperty, state.SortAscending);
            //pagging
            if (state.Page == null)
                state.Page = 1;
            listSetting.TakePage((int)state.Page, Properties.Settings.Default.CountItemInPage);
            //get sortedlist
            var list = listSetting.List().Select(model => Mapper.Map<CategoryViewModel>(model)).ToList();
            //get count item
            var count = listSetting.ItemCount();

            //setting paggination 
            var staticList = new StaticPagedList<CategoryViewModel>(list, (int)state.Page, Properties.Settings.Default.CountItemInPage, count);
          
            var pagginationList = new PagginationModelList<CategoryViewModel>(state,staticList);

            return View(pagginationList);
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
