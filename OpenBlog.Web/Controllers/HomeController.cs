﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }
}