namespace DianaMVC.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
