using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var things = _context.Users.Find(-1);
            if (things == null)
            {
                return NotFound();
            }
            return Ok(things);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var things = _context.Users.Find(-1);
            var thingsToReturn = things.ToString();

            return thingsToReturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return "Bad Request";
        }
    }
}