﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ShopMall.Models;
using ShopMall.Services;
using ShopMall.ViewModels.Manage;
using Microsoft.AspNet.Http;




using ShopMall.Models.AccountDBModels;
using ShopMall.Models.ShopMallDBModels;
using System.IO;

namespace ShopMall.Controllers
{
    [Authorize]
    public partial class ManageController : Controller
    {

        [HttpGet]
        public IActionResult ManageShopGoods()
        {
            var currentUser = _repository.GetCurrentUser(User.Identity.Name);
            if (currentUser != null)
            {
       
                var Shop   = _repository.GetUserShop(currentUser);
       
                ViewBag.Goods = _repository.ShopGoods(Shop.Id).ToList();
            }
            else {
                Redirect("/");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateGood()
        {
            return View();
        }
        [HttpPost  ]
        public IActionResult CreateGood(CreateGoodViewModel model, ICollection<IFormFile> newimages)
        {
            if (ModelState.IsValid) {
                //тек пользователь
                var currentUser = _repository.GetCurrentUser(User.Identity.Name);
                
                //соответсвующий магазин
                Shop shop = new Shop();
                if (currentUser != null)
                    shop = _repository.GetUserShop(currentUser);

                Good newgood = new Good() { Title = model.Title, Description = model.Description, CategoryId = Convert.ToInt32(model.Category)};

                _repository.CreateShopGood(newgood, shop, newimages);

                return RedirectToAction("ManageShopGoods");
            }
            return RedirectToAction("ManageShopGoods");
        }


        public IActionResult ManageShopSales()
        {
            return View();
        }
        public IActionResult ManageShopPurchases()
        {
            return View();
        }
        public IActionResult ManageShopDiscounts()
        {
            return View();
        }
        public IActionResult ManageShopProfile()
        {
            return View();
        }




    }
}
