using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MierzepAPIv2.Application.Authors.Command.CreateAuthor;
using MierzepAPIv2.Application.Directors.Queries.GetAuthorDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MierzepAPIv2.Controllers
{
    /// <summary>
    /// Authors controller
    /// </summary>
    [Route("api/authors")]
    public class AuthorsController : BaseController
    {
        /// <summary>
        /// Get Author Detail
        /// </summary>
        /// <param name="id">Set id</param>
        /// <returns>AuthorDetailVm</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<AuthorDetailVm> GetDetailVmAsync(int id)
        {
            var vm = await Mediator.Send(new GetAuthorDetailQuery() { AuthorId = id });

            return vm;
        }

        /// <summary>
        /// Create new Author.
        /// </summary>
        /// <param name="createAuthorCommand"></param>
        /// <returns>ID</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
        {
            var result = await Mediator.Send(createAuthorCommand);

            return Created(nameof(GetAuthorDetailQuery), result);
        }
    }
}
