using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using yungching_web_WebAPI.Models;
using yungching_web_WebAPI.Repository;

namespace yungching_web_WebAPI.Controllers
{
    /// <summary>
    /// Customer APIs.
    /// </summary>
    public class CustomersController : ApiController
    {
        private IRepository<Customer> repo;

        public CustomersController()
            : this(new Repository<Customer>(new NorthwindEntities()))
        {
        }

        public CustomersController(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        // GET: api/Customers
        /// <summary>
        /// Get all Customers.
        /// </summary>
        /// <returns>IQueryable&lt;Customer&gt;.</returns>
        public IQueryable<Customer> GetCustomers()
        {
            return repo.Reads();
        }

        // GET: api/Customers/5
        /// <summary>
        /// Get Customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            Customer customer = repo.Read(x => x.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customers
        /// <summary>
        /// Create Customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customer.CustomerID == null || CustomerExists(customer.CustomerID))
            {
                return BadRequest("Invalid CustomerID");
            }

            if (customer.CompanyName == null)
            {
                return BadRequest("Invalid CompanyName");
            }

            repo.Create(customer);
            repo.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);

        }

        // PUT: api/Customers/5
        /// <summary>
        /// Update Customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(string id, [FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CustomerExists(id))
            {
                return BadRequest("Assigned id does not exist.");
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            repo.Update(customer);
            repo.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);

        }

        // DELETE: api/Customers/5
        /// <summary>
        /// Delete Customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            var customer = repo.Read(x => x.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            repo.Delete(customer);
            repo.SaveChanges();

            return Ok(customer);

        }

        private bool CustomerExists(string id)
        {
            return repo.Reads().Count(e => e.CustomerID == id) > 0;
        }
    }
}
