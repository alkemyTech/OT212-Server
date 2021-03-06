using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentBusiness _commentBusiness;

        public CommentsController(ICommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
        {
            var comments = _commentBusiness.GetAll();

            var result = await comments;
            System.Diagnostics.Debug.WriteLine(result.Count);
            if (result.Count == 0)
            {
                return NotFound("Comment list is empty");
            }

            return Ok(result.OrderBy(x => x.LastModified).Select(x => x.MapToCommentDto()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles= "Administrador")]
        public async Task<ActionResult<Comment>> GetById(int id)
        {
            try
            {
                var entity = await _commentBusiness.GetById(id);
                if(entity != null)
                    return Ok(new Response<Comment>(entity, true));
                return NotFound(new Response<Comment>(null, false, null, ResponseMessage.NotFound));
            }
            catch
            {
                return BadRequest(new Response<Comment>(null, false, null, ResponseMessage.Error));
            }
        }

        #endregion

        #region Post

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentInsertDto>> CreateComment([FromForm] CommentInsertDto commentDto)
        {
            try
            {
                var userClaim = HttpContext.User.Identity as ClaimsIdentity;
                var userId = int.Parse(userClaim.FindFirst(x => x.Type == "Id").Value);

                if (userId == commentDto.UserId)
                {
                    await _commentBusiness.Insert(commentDto);
                    return Ok(new Response<CommentInsertDto>(commentDto, true));
                }
                return Unauthorized(new Response<CommentInsertDto>(null, false, null, ResponseMessage.ValidationErrors));
            }
            catch (Exception)
            {
                return BadRequest(new Response<CommentInsertDto>(null, false, null, ResponseMessage.Error));
            }
        }
        #endregion

        #region Update
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Comment>> UpdateComment(int id, [FromForm] CommentUpdateDto commentDto)
        {
            var userClaim = HttpContext.User.Identity as ClaimsIdentity;
            var userId = int.Parse(userClaim.FindFirst(x => x.Type == "Id").Value);
            var role = User.FindFirst(ClaimTypes.Role).Value.ToString();

            try
            {
                var check = await _commentBusiness.GetById(id);
                if (check == null) 
                   return NotFound(new Response<CommentUpdateDto>(null, false, new string[1] { "An entity is missing" }, ResponseMessage.NotFound));

                if (userId == check.UserId || role.Equals("Administrador"))
                {
                    var resp = await _commentBusiness.Update(id, commentDto);
                    return Ok(new Response<CommentDto>(resp, true, null, ResponseMessage.Success));
                }
                return StatusCode(403);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CommentUpdateDto>(null, false, new string[1] { "Bad request error" }, ex.Message));
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<CommentDto>> DeleteComment(int id)
        {
            try
            {
                var userClaim = HttpContext.User.Identity as ClaimsIdentity;
                var commentUserId = int.Parse(userClaim.FindFirst(x => x.Type == "Id").Value);
                var user = await _commentBusiness.GetById(id);

                if (user?.UserId == commentUserId)
                {
                    var entity = await _commentBusiness.Delete(id);
                    return Ok(new Response<CommentDto>(entity, true));
                }
                return Unauthorized(new Response<CommentDto>(null, false, null, ResponseMessage.ValidationErrors));
            }        
            catch (KeyNotFoundException)
            {
                return NotFound(new Response<CommentDto>(null, false, null, ResponseMessage.NotFound));
            }
            catch
            {
                return BadRequest(new Response<CommentDto>(null, false, null, ResponseMessage.Error));
            }
        }
        #endregion
    }
}
