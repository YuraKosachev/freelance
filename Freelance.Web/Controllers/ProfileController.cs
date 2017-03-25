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

namespace Freelance.Web.Controllers
{
    [Authorize(Roles ="freelance")]
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
        [Authorize(Roles = "freelance, client")]
        // GET: Profile
        public ActionResult Index()
        {
            var list = ProfileService.GetList().Select(m => new ProfileListViewModel {
                Id = m.Id,
                CategoryName = m.Category.NameCategory,
                FreelancerName = String.Format("{0} {1}",m.User.UserFirstName,m.User.UserSurname),
                DescriptionProfile = m.DescriptionProfile,
                TimeFrom = m.TimeFrom,
                TimeTo = m.TimeTo,
                UserId = m.UserId
            });
            
            return View(new PagedList<ProfileListViewModel>(list,0,10));
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

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

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
