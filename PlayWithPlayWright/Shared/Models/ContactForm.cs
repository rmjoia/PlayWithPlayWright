using System.ComponentModel.DataAnnotations;

namespace PlayWithPlayWright.Shared.Models;

public class ContactForm
{
    [Required(ErrorMessage = "The Name field is required")]
    [MaxLength(255, ErrorMessage = "The Name field can't be longer than 255 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Subject field is required")]
    [MaxLength(255, ErrorMessage = "The Subject field can't be longer than 255 characters")]
    public string? Subject { get; set; }

    [Required(ErrorMessage = "The Email field is required")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The Email entered is not a valid e-mail address")]
    [MaxLength(255, ErrorMessage = "The Email field can't be longer than 255 characters")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "The Message field is required")]
    [MaxLength(255, ErrorMessage = "The Message field can't be longer than 3000 characters")]
    public string? Message { get; set; }
}