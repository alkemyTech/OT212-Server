using Microsoft.AspNetCore.Mvc;
using OngProject.DataAccess;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SlideController(AppDbContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slide>>> GetAllSlides()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Post
        /* To Do:
         * Change Slide for SlideDto or SlideCreate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPost]
        public async Task<ActionResult<Slide>> CreateSlide([FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        /* To Do:
         * Change Slide for SlideUpdateDto or SlideUpdate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPut]
        public async Task<ActionResult<Slide>> UpdateSlide(int id, [FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        /* To Do:
         * Change Slide for SlideDeleteDto or SlideDelete (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpDelete]
        public async Task<ActionResult<Slide>> DeleteSlide(int id, [FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
