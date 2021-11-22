using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_097_C.Models.Upload;

namespace UCP1_PAW_097_C.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileProvider fileProvider;
        public UploadController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.GetFileName());

            using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }

            return RedirectToAction("Files");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0) return Content("files not selected");

            foreach (var file in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.GetFileName());

                using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }
            }

            return RedirectToAction("Files");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileViaModel(FileInputModel model)
        {
            if (model == null || model.FiletoUpload == null || model.FiletoUpload.Length == 0) 
                return Content("file not selected");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.FiletoUpload.GetFileName());

            using (var stream = new FileStream(path, FileMode.Create)) { await model.FiletoUpload.CopyToAsync(stream); }

            return RedirectToAction("Files");
        }

        public IActionResult Files() 
        { 
            var model = new FilesViewModel(); 
            foreach (var item in this.fileProvider.GetDirectoryContents("")) 
            { 
                model.Files.Add(new FileDetails 
                { 
                    Name = item.Name, Path = item.PhysicalPath 
                }); 
            } 
            return View(model); 
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null) return Content("filename not present");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);

            var memory = new MemoryStream(); using (var stream = new FileStream(path, FileMode.Open)) { await stream.CopyToAsync(memory); }
            memory.Position = 0; return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path) 
        { 
            var types = GetMimeTypes(); 
            var ext = Path.GetExtension(path).ToLowerInvariant(); 
            return types[ext]; 
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"}
            };
        }
    }
}
