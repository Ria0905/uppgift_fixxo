using Api.Contexts;

namespace Api.Helpers.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
    }
}
