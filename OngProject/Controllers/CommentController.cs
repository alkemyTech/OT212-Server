using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentBusiness _commentBusiness;

        public CommentController(ICommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
        {
            var comments = _commentBusiness.GetAll();

            var result = await comments;

            if(result.Count == 0)
            {
                return NotFound("Comment list is empty");
            }

            return Ok(result.Select(x => x.MapToCommentDto()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
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
