using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        public IActionResult Index()
        {
            var values = _service.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _service.TAdd(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = _service.GetById(id);
            _service.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _service.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var values = _service.GetById(category.Id);
            _service.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
