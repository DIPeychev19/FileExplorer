using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

public class FileExplorerController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public FileExplorerController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(UploadFileModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.File != null && model.File.Length > 0)
            {
                using (var reader = new StreamReader(model.File.OpenReadStream()))
                {
                    model.FileContent = await reader.ReadToEndAsync();
                }

                return View("FileContent", model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please select a file to upload.");
            }
        }

        return View("Index", model);
    }

}
