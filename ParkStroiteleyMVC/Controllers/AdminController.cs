﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ParkStroiteleyMVC.Controllers.Core.Interface;

namespace ParkStroiteleyMVC.Controllers
{
    public class AdminController : Controller
    {
        private Action<string> Logs => Startup.Logs;
        private readonly ILogger<AdminController> _logger;

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
        public string News(List<IFormFile> images)
        {
            var d = HttpContext;
            if (images != null && images.Count() != 0)
            {
                var now = DateTime.Now.ToString("yyyyMMddHHmmss");
                int i = 0;
                foreach (var file in images)
                {
                    var w = file.FileName.Split('.').Last();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), now + "_" + i.ToString() + "." + w);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    i++;
                }
            }
            return "okk";
        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
