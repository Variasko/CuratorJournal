using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CuratorJournal.Api.Controllers
{
    
    public class ClassHourController : BaseController<ClassHour>
    {
        public ClassHourController(IClassHourService service) : base(service) { }
    }
}