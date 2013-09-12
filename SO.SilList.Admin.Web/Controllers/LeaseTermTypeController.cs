﻿using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class LeaseTermTypeController : Controller
    {
        //
        // GET: /LeaseTermType/

        private LeaseTermTypeManager leaseTermTypeManager = new LeaseTermTypeManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var results = leaseTermTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(int id, LeaseTermTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = leaseTermTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = leaseTermTypeManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(LeaseTermTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = leaseTermTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var result = leaseTermTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rental/_Menu");
        }

        public ActionResult Delete(int id)
        {
            leaseTermTypeManager.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.leaseTermType = leaseTermTypeManager.getAll(null);
            var leaseType = new LeaseTermTypeVo();
            if (id != null)
            {
                leaseType = leaseTermTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", leaseType);
        }
    }
}