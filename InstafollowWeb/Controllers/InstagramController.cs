using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace InstafollowWeb.Controllers
{
    public class InstagramController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            JObject data;
            using (var reader = new StreamReader(filePath))
            {
                var fileContent = await reader.ReadToEndAsync();
                data = JObject.Parse(fileContent);
            }

            var mutualFollowers = ExtractList(data, "mutual_followers");
            var unfollowers = ExtractList(data, "unfollowers");

            ViewBag.MutualFollowers = mutualFollowers;
            ViewBag.Unfollowers = unfollowers;

            return View("Index");
        }

        private List<string> ExtractList(JObject data, string key)
        {
            if (data == null || string.IsNullOrEmpty(key) || data[key] == null)
            {
                return new List<string>();
            }

            var list = new List<string>();
            foreach (var item in data[key] ?? new JArray())
            {
                list.Add(item.ToString());
            }

            return list;
        }
    }
}