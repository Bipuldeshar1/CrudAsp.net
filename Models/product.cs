using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAsp.net.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public  DateTime CreatedDate { get; set; }
    
        public string? Image { get;set; }
    }
}
