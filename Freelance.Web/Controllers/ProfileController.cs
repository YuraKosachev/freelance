using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelance.Web.Models;
using PagedList.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Freelance.Service;
using Freelance.Service.ServicesModel;
using Freelance.Service.Interfaces;
using Freelance.Service.Services;
using Freelance.FreelanceException;
using Microsoft.Practices.Unity;

namespace Freelance.Web.Controllers
{
    public class ProfileControllerMapperProfile:Profile
    {
        public ProfileControllerMapperProfile()
        {
            CreateMap<ProfileServiceModel,ProfileViewModel>()
                .ForMember(item => item.TimeAvailability, exp => exp.MapFrom(src => String.Format("{0} - {1}", src.TimeFrom,src.TimeTo)));
            CreateMap<ProfileCreateEditViewModel, ProfileServiceModel>().ReverseMap();

           
        }

    }




    public class ProfileController : Controller
    {
        
        private  ICategoryService CategoryService { get; set; }
        private IProfileService ProfileService { get; set; }

        [InjectionConstructor]
        public ProfileController(ICategoryService categoryService, IProfileService profileService)
        {
            CategoryService = categoryService;
            ProfileService = profileService;
        }


        [Authorize(Roles = "freelancer, client")]
        // GET: Profile
        public ActionResult Index(IndexState state)
        {
            var listSetting = ProfileService.GetList();
            listSetting.SortPage("TimeFrom", true);
            if (state.Page == null)
                state.Page = 1;
            listSetting.TakePage((int)state.Page, Properties.Settings.Default.CountItemInPage);

            var list = listSetting.List().Select(model => Mapper.Map<ProfileViewModel>(model)).ToList();

            return View(new StaticPagedList<ProfileViewModel>(list, (int)state.Page, Properties.Settings.Default.CountItemInPage, listSetting.ItemCount()));
        }
        [Authorize(Roles = "freelancer")]
        public ActionResult MyProfiles(IndexState state)//int? page)
        {
            var listSetting = ProfileService.GetList();
            listSetting.Filter("UserId", User.Identity.GetUserId());
            listSetting.SortPage("TimeFrom", true);
            if (state.Page == null)
                state.Page = 1;
            listSetting.TakePage((int)state.Page, Properties.Settings.Default.CountItemInPage);

            var list = listSetting.List().Select(model => Mapper.Map<ProfileViewModel>(model)).ToList();
            
            return View(new StaticPagedList<ProfileViewModel>(list, (int)state.Page, Properties.Settings.Default.CountItemInPage, listSetting.ItemCount()));
        }
        // GET: Profile/Details/5
        [Authorize(Roles = "freelancer, client")]
        public ActionResult Details(Guid id)
        {
            try
            {
                var item = ProfileService.GetItem(id);
                return View(Mapper.Map<ProfileViewModel>(item));
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
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Create
        public ActionResult Create()
        {
            var profile = new ProfileCreateEditViewModel {
                Categories = CategoryService.Lookup()
            };
            return View(profile);
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = CategoryService.Lookup();
                return View(model);
            }
            try
            {
                // TODO: Add insert logic here

                ProfileService.Create(Mapper.Map<ProfileServiceModel>(model));
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                var item = Mapper.Map<ProfileCreateEditViewModel>(ProfileService.GetItem(id));
                item.Categories = CategoryService.Lookup();
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
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfileCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = CategoryService.Lookup();
                return View(model);
            }
            try
            {
                // TODO: Add update logic here
                ProfileService.Update(Mapper.Map<ProfileServiceModel>(model));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Delete/5
        public ActionResult Delete(Guid id)
        {
            var item = ProfileService.GetItem(id);
            return View(Mapper.Map<ProfileViewModel>(item));
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(ProfileViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                ProfileService.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
