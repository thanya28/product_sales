using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_sales.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace product_sales.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductSalesdatabasesContext _context;

        // Constructor to inject the DbContext
        public ProductRepository(ProductSalesdatabasesContext context)
        {
            _context = context;
        }

       

        #region -1 list of orderitem table
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItem()
        {
            try
            {
               
                if (_context != null)
                {
                    return await _context.OrderItems
                        .Include(order => order.Order)   
                        .Include(order => order.Product)  
                        .ToListAsync();
                }

              
                return new List<OrderItem>();
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
        #endregion

        #region 2 list of order table
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Orders
                        .Include(order => order.Customer)
                        .Include(order => order.Store)
                         .Include(order => order.Staff)
                            .Include(order => order.OrderItems)
                        .ToListAsync();
                }


                return new List<Order>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        #endregion
        #region 3 list of staff table
        public async  Task<ActionResult<IEnumerable<Staff>>> GetAllstaff()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Staffs
                       
                        .Include(order => order.Store)
                        
                        .ToListAsync();
                }


                return new List<Staff>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion
        #region  list of Brand table
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllbrand()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Brands.ToListAsync();
                }


                return new List<Brand>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion
        public async Task<ActionResult<IEnumerable<Category>>> GetAllcategory()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Categories.ToListAsync();
                }


                return new List<Category>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Customers.ToListAsync();
                }


                return new List<Customer>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<Manager>>> GetAllManager()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Managers.ToListAsync();
                }


                return new List<Manager>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Products

                        .Include(order => order.Category)
                         .Include(order => order.Brand)

                        .ToListAsync();
                }


                return new List<Product>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
           
        public async  Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Stocks

                        .Include(order => order.Store)

                        .Include(order => order.Product)

                        .ToListAsync();
                }


                return new List<Stock>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        
        public async Task<ActionResult<IEnumerable<Store>>> GetAllStore()
        {
            try
            {

                if (_context != null)
                {
                    return await _context.Stores

                        .Include(order => order.Manager)

                        .ToListAsync();
                }


                return new List<Store>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<ActionResult<OrderItem>> GetotById(int id)
        {
            try
            {
                if (_context != null)
                {
                    // find the employee by id 
                    var order = await _context.OrderItems
                    .Include(order => order.Order)
                     .Include(order => order.Product)
                    .FirstOrDefaultAsync(e => e.ItemId == id);
                    return order;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<OrderItem>> postotReturnRecord(OrderItem Orderitem)
        {
            try
            {
                if (Orderitem == null)
                {
                    throw new ArgumentNullException(nameof(Orderitem), "Orderitem data is null");

                }
              
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized.");
                }
               
                await _context.OrderItems.AddAsync(Orderitem);

              
                await _context.SaveChangesAsync();
               
                var cusorder = await _context.OrderItems.Include(e => e.Order).Include(e => e.Product)
                    .FirstOrDefaultAsync(e => e.ItemId == Orderitem.ItemId);
                return cusorder;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<int>> postotReturnId(OrderItem Orderitem)
        {
            try
            {
                if (Orderitem == null)
                {
                    throw new ArgumentNullException(nameof(Orderitem), "Orderitem data is null");

                }
               
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized.");
                }
              
                await _context.OrderItems.AddAsync(Orderitem);

               
                var changesRecord = await _context.SaveChangesAsync();
                if (changesRecord > 0)
                {
                    return Orderitem.ItemId;
                }
                else
                {
                    throw new Exception("failed to save employee record to the database");
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<OrderItem>> putot(int id, OrderItem Orderitem)
        {
            try
            {
                if (Orderitem == null)
                {
                    throw new ArgumentNullException(nameof(Orderitem), "Orderitem data is null");

                }
               
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized.");
                }
               
                var existingOrderItem = await _context.OrderItems.FindAsync(id);
                if (existingOrderItem == null)
                {
                    return null;
                }

              
                existingOrderItem.Quantity = Orderitem.Quantity;
                existingOrderItem.Price = Orderitem.Price;
                existingOrderItem.Discount = Orderitem.Discount;
                existingOrderItem.Product = Orderitem.Product;




              
                await _context.SaveChangesAsync();
              
                var cusorder = await _context.OrderItems.Include(e => e.Order).Include(e => e.Product)
                    .FirstOrDefaultAsync(e => e.ItemId == Orderitem.ItemId);
                return cusorder;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
