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
using Freelance.Web.Extensions;
//----------------
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

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
            if (!string.IsNullOrEmpty(state.SearchString))
            {
                state.SearchString.Trim();
                listSetting.Filter("User.UserFirstName.Contains(@0) OR User.UserSurname.Contains(@0) OR DescriptionProfile.Contains(@0)",state.SearchString);
            }
            if (state.TimeAvailability != null)
            {
                listSetting.FilterAnd("TimeFrom <= @0 AND TimeTo >= @0", (TimeSpan)state.TimeAvailability);//"TimeFrom <= @0 AND TimeTo >= @0", (TimeSpan)state.TimeAvailabilityFilter);
            }
            if ((state.CategoryId != null) && (state.CategoryId != Guid.Empty) )
            {
                listSetting.FilterAnd("CategoryId == @0", (Guid)state.CategoryId);
            }
            state.Categories = CategoryService.Lookup();
            state.Categories.Add(Guid.Empty, "All");
            listSetting.Sort(state, "TimeFrom").Page(state);
            var list = listSetting.StaticList<ProfileViewModel, ProfileServiceModel>(state);
            var pagginationList = new PagginationModelList<ProfileViewModel>(state, list);
            return View(pagginationList);
        }
        [Authorize(Roles = "freelancer")]
        public ActionResult FreelancerProfiles(IndexState state)
        {
            var listSetting = ProfileService.GetList();
            listSetting.Filter("UserId == @0", User.Identity.GetUserId());
            listSetting.Sort(state, "TimeFrom").Page(state);
            var list = listSetting.StaticList<ProfileViewModel, ProfileServiceModel>(state);
            var pagginationList = new PagginationModelList<ProfileViewModel>(state, list);

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
            state.Categories = CategoryService.Lookup();
            var profile = new ProfileViewModel {
                IndexState = state
            };
            
            return View(profile);
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProfileViewModel model, IndexState state)
        {
            if (!ModelState.IsValid)
            {
                model.IndexState.Categories = CategoryService.Lookup();
                return View(model);
            }
            try
            {
                // TODO: Add insert logic here
                var result = await Request.Content.ReadAsMultipartAsync(new MultipartFormDataStreamProvider(Path.GetTempPath()));

                var fileData = result.FileData.First();
                var formData = result.FormData;

                ProfileService.Create(Mapper.Map<ProfileServiceModel>(model));
 
                return RedirectToAction("FreelancerProfiles", state);
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
                item.IndexState = state;
                item.IndexState.Categories = CategoryService.Lookup();
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
                state.Categories = CategoryService.Lookup();
                model.IndexState = state;
                return View(model);
            }
            try
            {
                // TODO: Add update logic here
                ProfileService.Update(Mapper.Map<ProfileServiceModel>(model));
                return RedirectToAction("FreelancerProfiles", state);
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Delete/5
        public ActionResult Delete(Guid id,IndexState state)
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
                return RedirectToAction("FreelancerProfiles", state);
            }
            catch
            {
                return View();
            }
        }
    }
}
