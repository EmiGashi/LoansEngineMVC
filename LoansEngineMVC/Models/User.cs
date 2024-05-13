using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LoansEngineMVC.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "You must fill this box and it should be less than 50 characthers.")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "You must fill this box and it should be less than 50 characthers.")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "You must fill this box and it should be less than 50 characthers.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public string? Company { get; set; }

        public string? Title { get; set; }

        public string? Comment { get; set; }
        public string? Webinar { get; set; } = String.Empty;
    }
}
