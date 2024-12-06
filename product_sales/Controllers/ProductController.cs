using Microsoft.AspNetCore.Mvc;
using product_sales.Models;
using product_sales.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace product_sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
      
        #region 1 - Get all Orderitems - List    all orderiten
        [HttpGet("v1")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItem()
        {
            var orders = await _repository.GetAllOrderItem();
            if (orders == null)
            {
                return NotFound("No orders found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v2")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllstaff()
        {
            var orders = await _repository.GetAllstaff();
            if (orders == null)
            {
                return NotFound("No staffs found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v3")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrand()
        {
            var orders = await _repository.GetAllbrand();
            if (orders == null)
            {
                return NotFound("No Brand found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v4")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            var orders = await _repository.GetAllcategory();
            if (orders == null)
            {
                return NotFound("No Category found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v5")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            var orders = await _repository.GetAllCustomer();
            if (orders == null)
            {
                return NotFound("No Customer found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v6")]
        public async Task<ActionResult<IEnumerable<Manager>>> GetAllManager()
        {
            var orders = await _repository.GetAllManager();
            if (orders == null)
            {
                return NotFound("No Manager found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v7")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            var orders = await _repository.GetAllProduct();
            if (orders == null)
            {
                return NotFound("No Product found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all Stock
        [HttpGet("v8")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
        {
            var orders = await _repository.GetAllStock();
            if (orders == null)
            {
                return NotFound("No Stock found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all Store
        [HttpGet("v9")]
        public async Task<ActionResult<IEnumerable<Store>>> GetAllStore()
        {
            var orders = await _repository.GetAllStore();
            if (orders == null)
            {
                return NotFound("No Store found");
            }
            return Ok(orders);
        }
        #endregion
        #region 2 - List all orders
        [HttpGet("v0")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            var orders = await _repository.GetAllOrder();
            if (orders == null)
            {
                return NotFound("No Order found");
            }
            return Ok(orders);
        }
        #endregion
        #region Search by id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetotById(int id)
        {
            var order = await _repository.GetotById(id);
            if (order == null)
            {
                return NotFound("No order found ");
            }
            return Ok(order);
        }
        #endregion
        #region 4 insert an orderitem return orderitems record
        [HttpPost]
        public async Task<ActionResult<OrderItem>> postotReturnRecord(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                var neworder = await _repository.postotReturnRecord(orderitem);
                if (neworder != null)
                {
                    return Ok(neworder);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion
        #region 5 insert an orderitem return orderitem by id
        [HttpPost("v1")]
        public async Task<ActionResult<int>> postotReturnId(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                var newitemId = await _repository.postotReturnId(orderitem);
                if (newitemId != null)
                {
                    return Ok(newitemId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion
        #region update employee
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItem>> putot(int id, OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                var updateitem = await _repository.putot(id, orderitem);
                if (updateitem != null)
                {
                    return Ok(updateitem);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }
        #endregion
    }
}
