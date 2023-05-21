using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolShopEntities.Context;
using WedBanDungCuXayDung.Models;
using static WedBanDungCuXayDung.Models.Common;

namespace WedBanDungCuXayDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ToolShop objWebBanDungCuXayDung = new ToolShop();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objWebBanDungCuXayDung.Products.ToList();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        //tên hình
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        //tenhinh.png
                        objProduct.Image = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebBanDungCuXayDung.Products.Add(objProduct);
                    objWebBanDungCuXayDung.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objWebBanDungCuXayDung.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWebBanDungCuXayDung.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebBanDungCuXayDung.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();

            objWebBanDungCuXayDung.Products.Remove(objProduct);
            objWebBanDungCuXayDung.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objWebBanDungCuXayDung.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Image = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebBanDungCuXayDung.Entry(objProduct).State = EntityState.Modified;
            objWebBanDungCuXayDung.SaveChanges();
            return RedirectToAction("Index");
        }

        void LoadData()
        {
            Common objCommon = new Common();
            //Lấy dữ liệu danh mục dưới DB
            var lstCat = objWebBanDungCuXayDung.Categories.ToList();
            //Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            //Lấy dữ liệu thương hiệu dưới DB
            var lstBrand = objWebBanDungCuXayDung.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //Convert sang select list dạng value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //Convert sang select list dạng value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}