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
//using Freelance.Provider.Interfaces;
//using Freelance.Provider;
//using Freelance.Provider.EntityModels;

namespace Freelance.Web.Controllers
{
    public class ProfileControllerMapperProfile:Profile
    {
        public ProfileControllerMapperProfile()
        {
            CreateMap<ProfileListViewModel, ProfileServiceModel>();
        }

    }


    public class ProfileController : Controller
    {
        private ICategoryProvider CategoryService { get; set; }
        private IProfileProvider ProfileService { get; set; }
      

        public ProfileController()
        {
            var factory = new ProviderFactory();
            CategoryService = factory.CategoryProvider;
            ProfileService = factory.ProfileProvider;

        }
        [Authorize(Roles = "freelancer, client")]
        // GET: Profile
        public ActionResult Index(int? page)
        {
            var list = ProfileService.GetList().Select(m => new ProfileListViewModel {
                Id = m.Id,
                CategoryName = m.Category.NameCategory,
                FreelancerName = String.Format("{0} {1}", m.User.UserFirstName, m.User.UserSurname),
                PhoneNumber = m.User.PhoneNumber,
                DescriptionProfile = m.DescriptionProfile,
                TimeAvailability = String.Format("{0} - {1}", m.TimeFrom, m.TimeTo),
                UserId = m.UserId
            });
            
            return View(new PagedList<ProfileListViewModel>(list,1,1));
        }
        [Authorize(Roles = "freelancer")]
        public ActionResult MyProfiles(int? page)
        {
            var userId = User.Identity.GetUserId();

            var list = ProfileService.GetList().Select(m => new ProfileListViewModel
            {
                Id = m.Id,
                CategoryName = m.Category.NameCategory,
                FreelancerName = String.Format("{0} {1}", m.User.UserFirstName, m.User.UserSurname),
                DescriptionProfile = m.DescriptionProfile,
                TimeAvailability = String.Format("{0} - {1}", m.TimeFrom, m.TimeTo),
                UserId = m.UserId
            });

            return View(new PagedList<ProfileListViewModel>(list, 1, 10));
        }
        // GET: Profile/Details/5
        [Authorize(Roles = "freelancer, client")]
        public ActionResult Details(Guid id)
        {
            return View();
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

                ProfileService.Create(new Profile {
                    DescriptionProfile = model.DescriptionProfile,
                    TimeFrom = model.TimeFrom,
                    TimeTo = model.TimeTo,
                    UserId = model.UserId,
                    CategoryId = model.CategoryId,

                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Edit/5
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
        [Authorize(Roles = "freelancer")]
        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Authorize(Roles = "freelancer")]
        // POST: Profile/Delete/5
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
