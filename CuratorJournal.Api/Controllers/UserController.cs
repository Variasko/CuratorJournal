using CuratorJournal.Api.Controllers.Base;
using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace CuratorJournal.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController<User>
    {
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
        private readonly IServiceBase<User> _service;
        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(string login, string password)
        {
            var users = await _service.GetAllAsync();
            var user = users
                .Where(u=> u.Login == login && u.Password == password)
                .FirstOrDefault();
            if (user != null)
                return Ok(user);
            return NotFound();
        }
    }
}