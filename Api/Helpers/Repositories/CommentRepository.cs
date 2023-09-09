using Api.Contexts;
using Api.Models.Entities;

namespace Api.Helpers.Repositories
{
	public class CommentRepository : Repository<CommentEntity>
	{
		public CommentRepository(DataContext context) : base(context)
		{
		}
	}
}
