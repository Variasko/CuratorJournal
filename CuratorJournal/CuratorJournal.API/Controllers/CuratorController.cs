using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CuratorJournal.DataAccess.DTOs;
using CuratorJournal.DataAccess;

namespace CuratorJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuratorController : ControllerBase
    {

        private CuratorJournalEntities _db = new CuratorJournalEntities();

        [HttpPost("/SignIn")]
        public IActionResult SignIn(SignInDTO user)
        {
            try
            {
                User existingUser = _db.Users.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
                if (user == null)
                {
                    return NotFound("Пользователь не найден!");
                }
                else
                {
                    var curator = _db.Curators.Where(c => c.UserId == existingUser.UserId);
                    CuratorDTO curatorDTO = (CuratorDTO)curator.Select(c => new CuratorDTO
                    {
                        CategoryId = c.CategoryId,
                        CuratorId = c.CuratorId
                    });
                    return Ok(curatorDTO);
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
