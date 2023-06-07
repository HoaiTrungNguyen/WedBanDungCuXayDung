using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolShopEntities.Context;

namespace WedBanDungCuXayDung.Controllers
{
    public class CategoryController : Controller
    {
        ToolShop objWebBanDungCuXayDung = new ToolShop();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWebBanDungCuXayDung.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWebBanDungCuXayDung.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}