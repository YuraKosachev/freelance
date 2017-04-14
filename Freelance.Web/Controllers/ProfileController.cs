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
                .ForMember(item => item.TimeAvailability, exp => exp.MapFrom(src => String.Format("{0} - {1}", src.TimeFrom,src.TimeTo))).ReverseMap();
            //CreateMap<ProfileCreateEditViewModel, ProfileServiceModel>().ReverseMap();

           
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


        [Authorize(Roles = "client")]
        // GET: Profile
        public ActionResult Index(IndexState state)
        {
            var listSetting = ProfileService.GetList();
            //sorting
            if (string.IsNullOrEmpty(state.SortProperty))
                listSetting.SortPage("TimeFrom", ascending: true);
            else
                listSetting.SortPage(state.SortProperty, state.SortAscending);

            //filtring           
            if (!string.IsNullOrEmpty(state.SearchString))
            {
                state.SearchString.Trim();
                listSetting.Filter("User.UserFirstName.Contains(@0) OR User.UserSurname.Contains(@0) OR DescriptionProfile.Contains(@0)",state.SearchString);
            }
            if (state.TimeAvailabilityFilter != null)
            {
                listSetting.FilterAnd("TimeFrom <= @0 AND TimeTo >= @0", (TimeSpan)state.TimeAvailabilityFilter);//"TimeFrom <= @0 AND TimeTo >= @0", (TimeSpan)state.TimeAvailabilityFilter);
            }
            if (state.CategoryId != null)
            {
                listSetting.FilterAnd("CategoryId == @0", (Guid)state.CategoryId);
            }
                
            //pagging
            if (state.Page == null)
                state.Page = 1;
            listSetting.TakePage((int)state.Page, Properties.Settings.Default.CountItemInPage);

            var list = listSetting.List().Select(model => Mapper.Map<ProfileViewModel>(model)).ToList();
            //get count item
            var count = listSetting.ItemCount();
            //setting paggination 
            var staticList = new StaticPagedList<ProfileViewModel>(list, (int)state.Page, Properties.Settings.Default.CountItemInPage, count);

            var pagginationList = new PagginationModelList<ProfileViewModel>(state, staticList);
            return View(pagginationList);
        }
        [Authorize(Roles = "freelancer")]
        public ActionResult MyProfiles(IndexState state)
        {
            var listSetting = ProfileService.GetList();

            listSetting.Filter("UserId", User.Identity.GetUserId());
            //sorting
            if (string.IsNullOrEmpty(state.SortProperty))
                listSetting.SortPage("TimeFrom", ascending: true);
            else
                listSetting.SortPage(state.SortProperty, state.SortAscending);

            if (state.Page == null)
                state.Page = 1;
            listSetting.TakePage((int)state.Page, Properties.Settings.Default.CountItemInPage);

            var list = listSetting.List().Select(model => Mapper.Map<ProfileViewModel>(model)).ToList();
            var count = listSetting.ItemCount();
            //setting paggination 
            var staticList = new StaticPagedList<ProfileViewModel>(list, (int)state.Page, Properties.Settings.Default.CountItemInPage, count);

            var pagginationList = new PagginationModelList<ProfileViewModel>(state, staticList);

            return View(pagginationList);
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
        public ActionResult Create(IndexState state)
        {
            var profile = new ProfileViewModel {
                Categories = CategoryService.Lookup()
            };
            return View(profile);
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileViewModel model, IndexState state)
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
 
                return RedirectToAction("MyProfile",state);
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Edit/5
        public ActionResult Edit(Guid id,IndexState state)
        {
            try
            {
                var item = Mapper.Map<ProfileViewModel>(ProfileService.GetItem(id));
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
       
        public ActionResult Edit(ProfileViewModel model,IndexState state)
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
                return RedirectToAction("MyProfile", state);
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
        public ActionResult Delete(ProfileViewModel model,IndexState state)
        {
            try
            {
                // TODO: Add delete logic here
                ProfileService.Delete(model.Id);
                return RedirectToAction("MyProfile", state);
            }
            catch
            {
                return View();
            }
        }
    }
}
