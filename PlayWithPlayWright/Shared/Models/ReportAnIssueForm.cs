using System.ComponentModel.DataAnnotations;

namespace PlayWithPlayWright.Shared.Models;

public class ReportAnIssueForm
{
    [Required(ErrorMessage = "The Title field is required")]
    [MaxLength(60, ErrorMessage = "The Title field can't be longer than 60 characters")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "The Description field is required")]
    [MaxLength(120, ErrorMessage = "The Description field can't be longer than 120 characters")]
    public string? ShortDescription { get; set; }

    [Required(ErrorMessage = "The Issue Detected field is required!")]
    [DataType(DataType.Date, ErrorMessage = "Issue Detected must be a valid date")]
    [Range(typeof(DateOnly), "31/5/2023", "31/12/2025", ErrorMessage = "The Date of Birth can only be between the 31st of May of 2023 and the 31st of December of 2025!")]
    public DateOnly IssueDate { get; set; }

    [Required(ErrorMessage = "The Email field is required")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Email must be a valid email")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The Email entered is not a valid e-mail address")]
    [MaxLength(255, ErrorMessage = "The Email field can't be longer than 255 characters")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "The Description field is required")]
    [MaxLength(512, ErrorMessage = "The Description field can't be longer than 512 characters")]
    public string? Description { get; set; }
}
