using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Gía bán")]
        public decimal? Price { set; get; }

        [Display(Name = "Gía gốc")]
        public decimal? OriginalPrice { set; get; }

        [Display(Name = "Số lượng tồn")]
        public int? Stock { set; get; }

        [Display(Name = "Tên")]
        public string? Name { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string? Description { get; set; }

        [Display(Name = "Mô tả chi tiết sản phẩm")]
        public string? Details { get; set; }

        [Display(Name = "Seo mô tả")]
        public string? SeoDescription { get; set; }

        [Display(Name = "Seo tiêu đề")]
        public string? SeoTitle { get; set; }
        [Display(Name = "Seo tên gọi")]
        public string? SeoAlias { get; set; }
        public string? LanguageId { get; set; }

		public IFormFile? ThumbnailImage { get; set; }
    }
}
