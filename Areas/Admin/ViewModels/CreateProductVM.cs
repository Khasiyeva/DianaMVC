using System.ComponentModel.DataAnnotations;

namespace DianaMVC.Areas.Admin.ViewModels
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public char? Size { get; set; }
        public string? Material { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile MainPhoto { get; set; }
        [Required]
        public IFormFile HoverPhoto { get; set; }
        [Required]
        public List<IFormFile>? Photos { get; set; }
    }
}
