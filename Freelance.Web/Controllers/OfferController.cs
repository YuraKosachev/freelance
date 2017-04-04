﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Freelance.Service.Interfaces;
using Freelance.Web.Models;
using PagedList.Mvc;
using PagedList;
using AutoMapper;
using Freelance.Service.ServicesModel;
using Microsoft.AspNet.Identity;

namespace Freelance.Web.Controllers
{
    public class OfferControllerMapperProfile : Profile
    {
        public OfferControllerMapperProfile()
        {
            CreateMap<OfferViewModel, OfferServiceModel>()
                .ForMember(item => item.Date, exp => exp.MapFrom(src => src.Date.Add(src.Time)))
                .ReverseMap();
                //.ForMember(item=>item.Time,exp=>exp.MapFrom(src=>src.Date.))
              
        }

    }

    public class OfferController : Controller
    {
        private IOfferService OfferService { get; set; }
        [InjectionConstructor]
        public OfferController(IOfferService offerService)
        {
            OfferService = offerService;
        }

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

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(OfferViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                model.UserId = User.Identity.GetUserId();
               var offerId = OfferService.Create(Mapper.Map<OfferServiceModel>(model));
                return new JsonResult {Data = new {OfferId = offerId } };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message);
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
