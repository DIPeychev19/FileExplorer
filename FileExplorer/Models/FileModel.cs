using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class UploadFileModel
{
    [Required(ErrorMessage = "Please select a file.")]
    [Display(Name = "File")]
    public IFormFile File { get; set; }

    public string FileContent { get; set; }
}
