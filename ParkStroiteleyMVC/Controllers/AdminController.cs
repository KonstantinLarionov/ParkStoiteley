using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ParkStroiteleyMVC.Controllers.Core.Interface;
using System.Drawing;
using ParkStroiteleyMVC.Models.ObjectDTO;
using ParkStroiteleyMVC.Models;

namespace ParkStroiteleyMVC.Controllers
{
    public class User
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
    }
    public class AdminController : Controller
    {
        private Action<string> Logs => Startup.Logs;
        private readonly ILogger<AdminController> _logger;
        private DBContext db = new DBContext(new DbContextOptions<DBContext>());
        public static IAdminDispatcher Dispatcher;

        public AdminController(ILogger<AdminController> logger)
        {
            if (Dispatcher == null)
                Logs.Invoke("Dispatcher was NULL! Check youre middleware.");

            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
       
        [HttpPost]
        public string News(string? news, List<string> blocks, List<IFormFile> imgs)
        {
            var mynew = JsonSerializer.Deserialize<NewDTO>(news);
            var myblocks = new List<BlockDTO>();
            foreach (var item in blocks)
            {
                myblocks.Add(JsonSerializer.Deserialize<BlockDTO>(item));
            }
            mynew.Blocks = myblocks;
            if (imgs != null && imgs.Count() != 0)
            {
                var now = DateTime.Now.ToString("yyyyMMddHHmmss");
                int i = 0;
                foreach (var file in imgs)
                {
                    var w = file.FileName.Split('.').Last();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), now + "_" + i.ToString() + "." + w);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    i++;
                }
                db.News.Add(mynew);
                db.SaveChanges();
                return $"Новость добавлена, Блоков: {myblocks.Count()}, Файлов: {imgs.Count()}";
            }
            return "error";
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
