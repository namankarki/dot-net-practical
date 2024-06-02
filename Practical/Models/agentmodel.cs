using System.ComponentModel.DataAnnotations;

namespace Practical.Models
{
    public class agentmodel
    {
        [Key]


        public int Id { get; set; }
        [Required(ErrorMessage = "Ohh")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ohh! NO")]
        [StringLength(8, MinimumLength = 3)]
        public string Description { get; set; }

    }
}
