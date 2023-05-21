using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolShopEntities.Context;

namespace WedBanDungCuXayDung.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ToolShop objWebBanDungCuXayDung = new ToolShop();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var lstProduct = new List<Product>();
            lstProduct = objWebBanDungCuXayDung.Products.ToList();
            return View(lstProduct);

        }
    }
}