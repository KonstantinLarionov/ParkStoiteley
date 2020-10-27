﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

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

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(Dispatcher.Index);
        }
    }
}