using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freelance.Web.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer
        [Authorize(Roles = "freelancer, client")]
        public ActionResult Index(int? page)
        {
            return View();
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
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

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Offer/Edit/5
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

        // GET: Offer/Delete/5
        [Authorize(Roles = "client")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Offer/Delete/5
        [Authorize(Roles = "client")]
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
