using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCP1_PAW_097_C.Models.Upload
{
    public class FileInputModel
    {
        public IFormFile FiletoUpload { get; set; }
    }
}
