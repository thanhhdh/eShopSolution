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
        [Required(ErrorMessage = "Bạn phải nhập giá bán")]
        public decimal? Price { set; get; }

        [Display(Name = "Gía gốc")]
        [Required(ErrorMessage = "Bạn phải nhập giá gốc")]
        public decimal? OriginalPrice { set; get; }

        [Display(Name = "Số lượng tồn")]
        [Required(ErrorMessage = "Bạn phải nhập số lượng tồn")]
        public int? Stock { set; get; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string? Name { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả sản phẩm")]
        public string? Description { get; set; }

        [Display(Name = "Mô tả chi tiết sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả chi tiết sản phẩm")]
        public string? Details { get; set; }

        [Display(Name = "Seo mô tả")]
        [Required(ErrorMessage = "Bạn phải nhập seo mô tả cho sản phẩm")]
        public string? SeoDescription { get; set; }

        [Display(Name = "Seo tiêu đề")]
        [Required(ErrorMessage = "Bạn phải nhập seo tiêu đề cho sản phẩm")]
        public string? SeoTitle { get; set; }
        [Display(Name = "Seo tên gọi")]
        public string? SeoAlias { get; set; }


        public string? LanguageId { get; set; }
        public IFormFile? ThumbnailImage { get; set; }
    }
}
