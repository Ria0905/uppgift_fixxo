using _01_AspNetMVC.Models.Dtos;

namespace _01_AspNetMVC.ViewModels
{
    public class CollectionViewModel
	{
		public IEnumerable<Product> Products { get; set; } = new List<Product>();
	}
}
