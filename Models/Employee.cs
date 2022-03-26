using System.ComponentModel.DataAnnotations.Schema;
namespace LineMonitoring.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? BatchId { get; set; }
        public string? ProductId { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; } = default!;
    }
}