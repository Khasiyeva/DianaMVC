using System.ComponentModel.DataAnnotations;

namespace DianaMVC.Areas.Admin.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<int>? ColorIds { get; set; }
        public List<int>? MaterialIds { get; set; }

        public IFormFile? MainPhoto { get; set; }
        [Required]
        public IFormFile? HoverPhoto { get; set; }
        [Required]
        public List<IFormFile>? Photos { get; set; }
    }
}
