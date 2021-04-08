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
        // GET: AdminController
        public IActionResult Index()
        {
            return null;
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            return null;

        }

        // GET: AdminController/Create
        [HttpPost]
        public IActionResult CreateProduct()
        {
            return null;
        }
        [HttpPost]
        public IActionResult CreateCategory()
        {
            return null;
        }
        [HttpPost]
        public IActionResult CreateAuthor()
        {
            return null;
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;

            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return null;

        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;

            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return null;

        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;

            }
        }
    }
}
