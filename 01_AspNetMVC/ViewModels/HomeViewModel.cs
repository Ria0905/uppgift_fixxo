using _01_AspNetMVC.Models;
using _01_AspNetMVC.Models.Dtos;

namespace _01_AspNetMVC.ViewModels
{
	public class HomeViewModel
	{
        public IEnumerable<Product> Featured { get; set; } = new List<Product>();
        public IEnumerable<Product> Popular { get; set; } = new List<Product>();
        public IEnumerable<Product> New { get; set; } = new List<Product>();
	}
}
