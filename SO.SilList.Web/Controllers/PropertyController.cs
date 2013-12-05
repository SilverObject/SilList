﻿using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{

    public class PropertyController : Controller
    {
        private PropertyManager propertyManager = new PropertyManager();
        private CityTypeManager cityTypeManager = new CityTypeManager();
        private StateTypeManager stateTypeManager = new StateTypeManager();
        private CountryTypeManager countryTypeManager = new CountryTypeManager();
        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();
        private PropertyListingTypeManager propertyListingTypeManager = new PropertyListingTypeManager();


        public ActionResult Index(PropertyVm input = null, Paging paging = null)
        {
            if (input == null) input = new PropertyVm();
            input.isActive = true;
            input.paging = paging;
            //if (input.property.bedrooms.ToString() == "Single")
                  //  input.property.bedrooms = 0; 

            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = propertyManager.search(input);
                return View(input);
            }
            return View(input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(PropertyVm input)
        {
            return PartialView("_Filter", input);
        }
        //public JsonResult Search(string keyword)
        //{
        //    var result = cityTypeManager.search(keyword);

        //   var json = Json(result, JsonRequestBehavior.AllowGet);
        //   return json;
        //}

        public ActionResult DropDownList(int? id = null, string propertyName = null, Type propertyType = null, string defaultValue = null, int? propertyTypeId = null)
        {
            //var item = Activator.CreateInstance(modelType);
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            ViewBag.selectedItem = id;
            if (propertyType == typeof(PropertyTypeVo))
            {
                ViewBag.items = propertyTypeManager.getAll(true);
                ViewBag.idName = "propertyTypeTypeId";
            }
            else if (propertyType == typeof(PropertyListingTypeVo))
            {
                ViewBag.items = propertyListingTypeManager.getAll(true);
                ViewBag.idName = "propertyTypeTypeId";
            }
            else if (propertyType == typeof(CountryTypeVo))
            {
                ViewBag.items = countryTypeManager.getAll(true);
                ViewBag.idName = "countryTypeId";
            }
            else if (propertyType == typeof(StateTypeVo))
            {
                ViewBag.items = stateTypeManager.getAll(true);
                ViewBag.idName = "stateTypeId";
            }
            else if (propertyType == typeof(CityTypeVo))
            {
                ViewBag.items = cityTypeManager.getAll(true);
                ViewBag.idName = "cityTypeId";
            }

            return PartialView("_DropDownList");
        }

        public ActionResult CollapseListType(int? id = null, string propertyName = null)
        {
            ViewBag.selectedId = id;
            ViewBag.propertyName = propertyName;
            ViewBag.list = propertyTypeManager.getAll(true);
            ViewBag.propertyTypeId = "propertyTypeId";
            //ViewBag.titleName = propertyTypeManager.get((int)propertyTypeId).name;
            return PartialView("_CollapseList");
        }

        public ActionResult Detail(Guid id)
        {
            var result = propertyManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            // ViewBag.Images = imageManager.getCarImages(id);
            ViewBag.ImagesURL = imageManager.getPropertyImagesUrl(id);
            return View(result);
        }
        public ActionResult Create()
        {
            var vo = new PropertyVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Create(PropertyVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = propertyManager.insert(input);

                ImageManager imageManager = new ImageManager();

                imageManager.InsertUploadImages(item.propertyId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.propertyImage);

                return RedirectToAction("Index");
            }

            return View(input);
        }

        public ActionResult CollapseList(int? id = null, string propertyName = null, Type propertyType = null)
        {
            ViewBag.selectedId = id;
            ViewBag.propertyName = propertyName;

            if (propertyType == typeof(PropertyTypeVo))
            {
                ViewBag.list = propertyTypeManager.getAll(true);
                ViewBag.propertyId = "propertyTypeId";
                ViewBag.titleName = "Property Type";
            }
            else if (propertyType == typeof(PropertyListingTypeVo))
            {
                ViewBag.list = propertyListingTypeManager.getAll(true);
                ViewBag.propertyId = "propertyListingTypeId";
                ViewBag.titleName = "Listing Type";
            }

            return PartialView("_CollapseList");
        }

    }
}





/*
namespace SO.SilList.Web.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /Rentals/

        private PropertyManager rentalManager = new PropertyManager();

        public ActionResult Index(PropertyVm input = null)
        {
            if (input == null) input = new PropertyVm();

            if (this.ModelState.IsValid)
            {
                input = rentalManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Filter(PropertyVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

*/