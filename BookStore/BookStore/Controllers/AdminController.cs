using BLL.ModelsDto;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //// GET: AdminController
        //public IActionResult Index()
        //{
        //    return null;
        //}

        //// GET: AdminController/Details/5
        //public IActionResult Details(int id)
        //{
        //    return null;

        //}

        [HttpPost("Create-Book")]
        public async Task CreateBook(BookDto bookDto) => await _adminService.CreateBook(bookDto);
        [HttpPost("Create-Category")]
        public async Task CreateCategory(CategoryDto categoryDto) => await _adminService.CreateCategory(categoryDto);
        [HttpPost("Create-Author")]
        public async Task CreateAuthor(AutorDto autorDto) => await _adminService.CreateAuthor(autorDto);


        //// POST: AdminController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return null;

        //    }
        //}

        //// GET: AdminController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return null;

        //}

        //// POST: AdminController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return null;

        //    }
        //}

        //// GET: AdminController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return null;

        //}

        //// POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return null;

        //    }
        //}
    }
}
