using System.Collections.Generic;
using System.Diagnostics;
using ANC.Sales.Data.Entities;
using ANC.Sales.Data.Repositories;
using AspNetCoreSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSales.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationRepository _repository;
        private readonly IUnitOfWork _uow;

        #region Ctor

        public HomeController(IApplicationRepository repository, IUnitOfWork uow)
        {
            this._repository = repository;
            this._uow = uow;
        }

        #endregion Ctor


        #region Public Actions

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAction()
        {
            return View();
        }

        public IActionResult Products()
        {
            var results = GetAll(false);

            return View(results);
        }

        #endregion Public Actions


        #region Private tests

        private Product Add()
        {
            var p = new Product()
            {
                Title = "Some product"
            };

            _uow.ProductRepository.Add(p);

            return p;
        }

        private IEnumerable<Product> GetAll(bool withUOW = true)
        {
            IEnumerable<Product> result = new List<Product>();

            if (withUOW)
            {
                result = _uow.ProductRepository.GetAll();
            }
            else
            {
                result = _repository.GetAllProducts();
            }

            return result;
        }

        #endregion Private tests
    }
}