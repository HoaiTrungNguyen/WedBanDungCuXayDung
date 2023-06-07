using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolShopEntities.Context;

namespace WedBanDungCuXayDung.Controllers
{
    public class ProductController : Controller
    {
        ToolShop objWebBanDungCuXayDung = new ToolShop();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebBanDungCuXayDung.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}