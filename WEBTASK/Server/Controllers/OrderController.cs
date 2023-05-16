using WEBTASK.Shared;
using Microsoft.AspNetCore.Mvc;
using WEBTASK.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace WEBTASK.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        //[HttpGet]
        //public IEnumerable<Order> Get()
        //{
            //List<Order> order = new List<Order>();
            //order.Add(new Order { id = 1, name = "test1", phone = 123, order = "test1", additional = "test1", address = "test1" });
            //order.Add(new Order { id = 2, name = "test2", phone = 123, order = "test2", additional = "test2", address = "test2" });
            //order.Add(new Order { id = 3, name = "test3", phone = 123, order = "test3", additional = "test3", address = "test3" });
            //return order;


             private readonly AppDbcontext _appDbContext;
        public OrderController(AppDbcontext appDbcontext)
        {

            _appDbContext = appDbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Order.Add(order);
                await _appDbContext.SaveChangesAsync();
                return Ok("Form data saved successfully!");
            }
            return BadRequest("Invalid form data");
        }

        [HttpGet]  //Output
        public async Task<ActionResult<List<Order>>> GetOrder()
        {
            var order = await _appDbContext.Order.ToListAsync();
            return Ok(order);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order updatedOrder)
        {
            //Check if the order exists
            var order = await _appDbContext.Order.FindAsync(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            // Update the order properties with the new values
            //Order order = new Order();

            order.id = updatedOrder.id;
            order.name = updatedOrder.name;
            order.phone = updatedOrder.phone;
            order.order = updatedOrder.order;
            order.additional = updatedOrder.additional;
            order.address = updatedOrder.address;


            // add more properties here as needed
            //_appDbContext.Order.Add(order);
            // Save the changes to the database
            await _appDbContext.SaveChangesAsync();

            // Return a success response
            return Ok(order);
        }


    }


       
    
}
