using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolShopEntities.Context;
using WedBanDungCuXayDung.Models;

namespace WedBanDungCuXayDung.Controllers
{
    public class HomeController : Controller
    {
        ToolShop objWebBanDungCuXayDung = new ToolShop();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();

            objHomeModel.ListCategory = objWebBanDungCuXayDung.Categories.ToList();
            objHomeModel.ListProduct = objWebBanDungCuXayDung.Products.ToList();
            return View(objHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}