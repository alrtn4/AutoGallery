using SazeNegar.Core.Models;
using SazeNegar.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace SazeNegar.Infrastructure.Repositories
{
    public class CartRepository : BaseRepository<Cart, MyDbContext>
    {
        private readonly MyDbContext _context;
        private readonly LogsRepository _logger;
<<<<<<< HEAD
        public CartRepository(MyDbContext context, LogsRepository logger) : base(context, logger)
=======
        public CartRepository(MyDbContext context, LogsRepository logger) : base(context , logger)
>>>>>>> master
        {
            _context = context;
            _logger = logger;
        }
        public Cart GetCart(int id)
        {
<<<<<<< HEAD
            return _context.Carts.FirstOrDefault(a => a.Id == id);
        }
        public List<Cart> GetCarts()
        {
            return _context.Carts.Where(e => e.IsDeleted == false).ToList();
        }
    }
}
=======
            return _context.Cart.FirstOrDefault(a => a.Id == id);
        }
        public List<Cart> GetCarts()
        {
            return _context.Cart.Where(e => e.IsDeleted == false).ToList();
        }
    }
}
>>>>>>> master
