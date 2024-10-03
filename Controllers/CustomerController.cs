using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values = _service.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _service.TAdd(customer);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _service.GetById(id);
            _service.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var values = _service.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var values = _service.GetById(customer.Id);
            _service.TUpdate(customer);
            return RedirectToAction("Index");
        }
    }
}
