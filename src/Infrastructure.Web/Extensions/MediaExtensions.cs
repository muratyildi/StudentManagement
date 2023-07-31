using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Web.Extensions
{
    public static class MediaExtensions
    {
        public static string ToBase64String(this IFormFile fromFile)
        {
            using MemoryStream ms = new MemoryStream();
            fromFile.CopyTo(ms);
            return "data:" + fromFile.ContentType + ";base64," + Convert.ToBase64String(ms.ToArray());
        }

        public static string ToBase64String(this byte[] byteArray, string contentType)
        {
            return "data:" + contentType + ";base64," + Convert.ToBase64String(byteArray);
        }
    }
}
