using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { set; get; }
        [Display(Name = "Mã sản phẩm")]
        public decimal Price { set; get; }
        [Display(Name = "Gía bán")]
        public decimal OriginalPrice { set; get; }
        [Display(Name = "Gía gốc")]
        public int Stock { set; get; }
        [Display(Name = "Số lượng tồn")]
        public int ViewCount { set; get; }
        [Display(Name = "Số lượng xem")]
        public DateTime DateCreated { set; get; }
        public string? Name { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string? Description { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string? Details { get; set; }
        [Display(Name = "Mô tả chi tiết sản phẩm")]
        public string? SeoDescription { get; set; }
        [Display(Name = "Seo mô tả")]
        public string? SeoTitle { get; set; }
        [Display(Name = "Seo tiêu đề")]
        public string? SeoAlias { get; set; }
        [Display(Name = "Seo tên gọi")]
        public string? LanguageId { get; set; }
		public bool IsFeatured { get; set; }

		public List<string> Categories { get; set; } = new List<string>();
    }
}
