using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UCP1_PAW_097_C.Models.Upload
{
    public static class IFormFileExtensions
    {
        public static string GetFileName(this IFormFile file)
        {
            return ContentDispositionHeaderValue.Parse(
                file.ContentDisposition).FileName.ToString().Trim('"');
        }

        public static async Task<MemoryStream> GetFileStream(this IFormFile file)
        {
            MemoryStream fileStream = new MemoryStream();
            await file.CopyToAsync(fileStream);
            return fileStream;
        }

        public static async Task<byte[]> GetFileArray(this IFormFile file)
        {
            MemoryStream fileStream = new MemoryStream();
            await file.CopyToAsync(fileStream);
            return fileStream.ToArray();
        }
    }
}
