using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WedBanDungCuXayDung.Models
{
    public class ProductMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string FullDescription { get; set; }
        [Display(Name = "Giá tiền")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giảm giá")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Slug URL")]
        public string Slug { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
    }
}