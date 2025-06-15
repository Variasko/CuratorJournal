using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CuratorJournal.Api.Controllers
{
    [Route("api/[controller]")]
    public class CuratorCharacteristicController : BaseController<CuratorCharacteristic>
    {
        public CuratorCharacteristicController(ICuratorCharacteristicService service) : base(service) { }
    }
}