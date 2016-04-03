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

using ShopMall.Models.AccountDBModels;

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
        public IActionResult CreateGood(string Title, string Descritption)
        {
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