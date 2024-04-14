using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAsp.net.Models
{
    public class ProductDetail
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
 
        public IFormFile? Image { get; set; }
    }
}