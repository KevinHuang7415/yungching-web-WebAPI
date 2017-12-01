using System.Collections.Generic;
using System.Web.Http;

namespace yungching_web_WebAPI.Controllers
{
    /// <summary>
    /// Value APIs.
    /// </summary>
    public class ValuesController : ApiController
    {
        private static IList<string> Values = new List<string> { "value1", "value2" };

        // GET api/values
        /// <summary>
        /// Get all Values.
        /// </summary>
        /// <returns>IEnumerable&lt;string&gt;.</returns>
        public IEnumerable<string> Get() => Values;

        // GET api/values/5
        /// <summary>
        /// Get Value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Get(int id)
        {
            if (ValidId(id))
            {
                return Ok(Values[id]);
            }

            return BadRequest("Invalid id");            
        }

        // POST api/values
        /// <summary>
        /// Create Value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public void Post([FromBody]string value) => Values.Add(value);

        // PUT api/values/5
        /// <summary>
        /// Update Value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            if (ValidId(id))
            {
                Values[id] = value;
                return Ok();
            }

            return BadRequest("Invalid id");
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete Value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Delete(int id)
        {
            if (ValidId(id))
            {
                Values.RemoveAt(id);
                return Ok();
            }

            return BadRequest("Invalid id");
        }

        private bool ValidId(int id) => id >= 0 && id < Values.Count;
    }
}