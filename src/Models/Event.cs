using System.ComponentModel.DataAnnotations;
namespace EventLiteWeb.Models
{
    public class Event
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;
    }
}