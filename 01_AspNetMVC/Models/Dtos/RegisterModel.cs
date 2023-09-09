﻿using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC.Models.Dtos
{
	public class RegisterModel
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
