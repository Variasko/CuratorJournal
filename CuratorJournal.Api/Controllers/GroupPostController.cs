using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CuratorJournal.Api.Controllers
{
    [Route("api/[controller]")]
    public class GroupPostController : BaseController<GroupPost>
    {
        public GroupPostController(IGroupPostService service) : base(service) { }
    }
}