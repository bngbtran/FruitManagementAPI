using System.ComponentModel.DataAnnotations;

namespace FruitManagementAPI.Models
{
    public class Fruit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
