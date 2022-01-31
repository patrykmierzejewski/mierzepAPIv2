using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepAPIv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyAllowSpecificOrgins")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        /// <summary>
        /// This Post method Create IFromCollection
        /// </summary>
        /// <param name="collection">IFromCollection</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return Created("", "test");
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Edit for IFormCollection
        /// </summary>
        /// <param name="id">Id param</param>
        /// <param name="collection">IFormCollection</param>
        /// <returns>no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return Created("", id);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: HomeController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
