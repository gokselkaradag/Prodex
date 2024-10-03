using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        public IActionResult Index()
        {
            var values = _service.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator rules = new ProductValidator();
            ValidationResult results = rules.Validate(product);
            if (results.IsValid)
            {
                _service.TAdd(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _service.GetById(id);
            _service.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _service.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var values = _service.GetById(product.Id);
            _service.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
