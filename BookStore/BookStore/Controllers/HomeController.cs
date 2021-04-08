﻿using BLL;
using BookStore.Models;
using BookStore.UI.Models;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserBookService _bookService;

        public HomeController(ILogger<HomeController> logger, UserBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult GetBooks() => PartialView(_bookService.GetBooks());
        [HttpGet]
        public PartialViewResult GetCategories() => PartialView(_bookService.GetCategories());

        public IActionResult TermsOfService()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
