using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Core.Business;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityBusiness _activityBusiness;

        public ActivityController(ActivityBusiness activityBusiness)
        {
            _activityBusiness = activityBusiness;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Post
        /* To Do:
         * Change Activity for ActivityDto or ActivityCreate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPost]
        public async Task<ActionResult<Activity>> CreateActivity([FromForm] Activity activity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        /* To Do:
         * Change Activity for ActivityUpdateDto or ActivityUpdate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPut]
        public async Task<ActionResult<Activity>> UpdateActivity(int id, [FromForm] Activity activity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        /* To Do:
         * Change Activity for ActivityDeleteDto or ActivityDelete (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpDelete]
        public async Task<ActionResult<Activity>> DeleteActivity(int id, [FromForm] Activity activity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
