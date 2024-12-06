using Microsoft.AspNetCore.Mvc;
using product_sales.Models;

namespace product_sales.Repository
{
    public interface IProductRepository
    {
        #region 1 list or orderitem table
        public Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItem();
        #endregion
        #region 2 list of order table
        public Task<ActionResult<IEnumerable<Order>>> GetAllOrder();
        #endregion
        #region  list of staff table
        public Task<ActionResult<IEnumerable<Staff>>> GetAllstaff();
        #endregion
        #region  list of Brand table
        public Task<ActionResult<IEnumerable<Brand>>> GetAllbrand();
        #endregion
        #region  list of category table
        public Task<ActionResult<IEnumerable<Category>>> GetAllcategory();
        #endregion
        #region  list of Customer table
        public Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer();
        #endregion
        #region  list of Manager table
        public Task<ActionResult<IEnumerable<Manager>>> GetAllManager();
        #endregion
        #region list of Product table
        public Task<ActionResult<IEnumerable<Product>>> GetAllProduct();
        #endregion
        #region list of Stock table
        public Task<ActionResult<IEnumerable<Stock>>> GetAllStock();
        #endregion
        #region list of Store table
        public Task<ActionResult<IEnumerable<Store>>> GetAllStore();
        #endregion
        #region -serach orderitem by id 
        public Task<ActionResult<OrderItem>> GetotById(int id);
        #endregion
        #region  4-insert orderitem
        public Task<ActionResult<OrderItem>> postotReturnRecord(OrderItem Orderitem);
        #endregion
        #region 5 insert all orderitems
        public Task<ActionResult<int>> postotReturnId(OrderItem Orderitem);
        #endregion 
        #region 6 get orderitems by its id
        public Task<ActionResult<OrderItem>> putot(int id, OrderItem Orderitem);
        #endregion 
    }
}
