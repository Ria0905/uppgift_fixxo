using _01_AspNetMVC.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.Models.Dtos
{
	public class LoginModel
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;


		public static implicit operator LoginViewModel(LoginModel model)
		{
			return new LoginViewModel
			{
				Email = model.Email,
				Password = model.Password,
			};
		}
	}
}
