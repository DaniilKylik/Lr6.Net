using Microsoft.AspNetCore.Mvc;
using Lr6.Net.Models;
using Lr6.Net.Services;

namespace Lr6.Net.Controllers
{
	public class OrderController : Controller
	{
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(User user)
		{
			int age = DateTime.Now.Year - user.DateOfBirth.Year;
			if (age >= 16)
			{
				TempData["UserName"] = user.Name;
				return RedirectToAction("OrderQuantity");
			}
			ModelState.AddModelError("", "Вам має бути більше 16 років для замовлення.");
			return View(user);
		}

		[HttpGet]
		public IActionResult OrderQuantity()
		{
			return View();
		}

		[HttpPost]
		public IActionResult OrderQuantity(int quantity)
		{
			if (quantity < 1)
			{
				ModelState.AddModelError("", "Кількість товарів має бути додатньою.");
				return View();
			}

			TempData["Quantity"] = quantity;
			return RedirectToAction("OrderProducts");
		}

		[HttpGet]
		public IActionResult OrderProducts()
		{
			int quantity = Convert.ToInt32(TempData["Quantity"]);
			var products = new List<Product>();

			for (int i = 0; i < quantity; i++)
			{
				products.Add(new Product());
			}

			return View(products);
		}
		[HttpPost]
		public IActionResult OrderProducts(List<Product> products)
		{
			return View("Summary", products);
		}
		public IActionResult Summary(List<Product> products)
		{
			return View(products);
		}
	}

}
public class OrderController : Controller
{
    private readonly IAgeValidationService _ageValidationService;
    private readonly IProductService _productService;

    public OrderController(IAgeValidationService ageValidationService, IProductService productService)
    {
        _ageValidationService = ageValidationService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (_ageValidationService.IsValidAge(user.DateOfBirth, 16))
        {
            TempData["UserName"] = user.Name;
            return RedirectToAction("OrderQuantity");
        }

        ModelState.AddModelError("", "Вам має бути більше 16 років для замовлення.");
        return View(user);
    }

    [HttpGet]
    public IActionResult OrderQuantity()
    {
        return View();
    }

    [HttpPost]
    public IActionResult OrderQuantity(int quantity)
    {
        if (quantity < 1)
        {
            ModelState.AddModelError("", "Кількість товарів має бути додатньою.");
            return View();
        }

        TempData["Quantity"] = quantity;
        return RedirectToAction("OrderProducts");
    }

    [HttpGet]
    public IActionResult OrderProducts()
    {
        int quantity = Convert.ToInt32(TempData["Quantity"]);
        var products = _productService.GetProducts(quantity);

        return View(products);
    }

    [HttpPost]
    public IActionResult OrderProducts(List<Product> products)
    {
        return View("Summary", products);
    }

    public IActionResult Summary(List<Product> products)
    {
        return View(products);
    }
}
