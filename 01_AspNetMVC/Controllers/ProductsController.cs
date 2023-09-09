using _01_AspNetMVC.Models.Dtos;
using _01_AspNetMVC.Services;
using _01_AspNetMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace _01_AspNetMVC.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			CollectionViewModel model = new CollectionViewModel();
			model.Products = await _productService.GetAllAsync();

			return View(model);
		}

		public async Task<IActionResult> ProductDetails(int id)
		{
			var result = await _productService.GetByIdAsync(id);

            return View(result);
		}

	}
}
