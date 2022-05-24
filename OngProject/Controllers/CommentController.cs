using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentBusiness _commentBusiness;

        public CommentController(CommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllComments()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Post
        /* To Do:
         * Change Comment for CommentDto or CommentCreate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment([FromForm] Comment comment)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        /* To Do:
         * Change Comment for CommentUpdateDto or CommentUpdate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPut]
        public async Task<ActionResult<Comment>> UpdateComment(int id, [FromForm] Comment comment)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        /* To Do:
         * Change Comment for CommentDeleteDto or CommentDelete (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpDelete]
        public async Task<ActionResult<Comment>> DeleteComment(int id, [FromForm] Comment comment)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
