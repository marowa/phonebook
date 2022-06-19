using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookService phoneBookService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PhoneBookController(IPhoneBookService phoneBookService, IWebHostEnvironment webHostEnvironment)
        {
            this.phoneBookService = phoneBookService;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult MainPhoneBook()
        {
            List<PhoneBookModel> list = phoneBookService.GetAll();
            return View("MainPhoneBook", list);
        }
        public IActionResult InsertPhone()
        {
            return View("InsertPhone");
        }
        [HttpPost]
        public IActionResult SavePhone(PhoneBookModel obj)
        {
            if (ModelState.IsValid)
            {
                phoneBookService.Insert(obj);
            }
            return RedirectToAction("MainPhoneBook");
        }
        public IActionResult UpdatePhone(int id)
        {
            PhoneBookModel obj = phoneBookService.GetDataByID(id);
            return View("UpdatePhone", obj);
        }
        [HttpPost]
        public IActionResult SaveUpdate(PhoneBookModel obj)
        {
            if (ModelState.IsValid)
            {
                phoneBookService.Update(obj);
            }
            return RedirectToAction("MainPhoneBook");
        }
        public IActionResult DeletePhone(int id)
        {
            phoneBookService.Delete(id);
            return RedirectToAction("MainPhoneBook");
        }

        public IActionResult SearchNumber(string search)
        {
            List<PhoneBookModel> list = phoneBookService.SearchNumber(search);
            return PartialView("_MainPhoneBook", list);
        }
    }
}
