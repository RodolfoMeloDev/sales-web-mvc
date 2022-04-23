using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel(departments);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            string message;
            var obj = ReturnSeller(id, out message);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = message });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            string message;
            var obj = ReturnSeller(id, out message);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = message });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            string message;
            var obj = ReturnSeller(id, out message);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = message });
            }

            List<Department> departmens = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel(obj, departmens);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        private Seller ReturnSeller(int? id, out string message)
        {
            if (id == null)
            {
                message = "Id not provided";
                return null;
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                message = "Id not found";
                return null;
            }

            message = "";
            return obj;
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
