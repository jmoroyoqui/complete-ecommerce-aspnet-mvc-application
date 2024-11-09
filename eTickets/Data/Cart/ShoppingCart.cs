using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _Context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems{ get; set; }


        public ShoppingCart(AppDbContext context)
        {
            _Context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _Context.ShoppingCartItems.FirstOrDefault(n=>n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _Context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _Context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _Context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _Context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _Context.SaveChanges();
            }
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _Context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            return _Context.ShoppingCartItems.Where(n=>n.ShoppingCartId == ShoppingCartId).Select(n=>n.Movie.Price * n.Amount).Sum();            
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _Context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _Context.ShoppingCartItems.RemoveRange(items);
            await _Context.SaveChangesAsync();
        }
    }
}
