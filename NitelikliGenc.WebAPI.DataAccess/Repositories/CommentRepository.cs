using Microsoft.EntityFrameworkCore;
using NitelikliGenc.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitelikliGenc.WebAPI.DataAccess.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Comment>> GetAllAsync()
        {
          return await _context.Comments.Include(x => x.Product).ToListAsync();
        }
    }
}
