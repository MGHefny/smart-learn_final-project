using System.ComponentModel.DataAnnotations;

namespace SmartLearn.Models
{
    public class TrainerModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "write Email like example@gmail.com")]
        public string Email { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; }

        [Url(ErrorMessage = "please, enter correct url!")]
        public string Website { get; set; }
        public System.DateTime Creation_Date { get; set; }
    }
}