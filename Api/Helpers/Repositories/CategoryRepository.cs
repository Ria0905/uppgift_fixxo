using Api.Contexts;
using Api.Models.Entities;

namespace Api.Helpers.Repositories
{
	public class CategoryRepository : Repository<CategoryEntity>
	{
		public CategoryRepository(DataContext context) : base(context)
		{
		}
	}
}
