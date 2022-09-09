using Microsoft.AspNetCore.Mvc;

using CacheService.Services.Resident;
using CacheService.Services.Resident.Models;

namespace CacheService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdController : ControllerBase
    {
        /// <summary>
        /// Refresh
        /// </summary>
        /// <returns></returns>
        [HttpGet("Refresh")]
        public bool Refresh()
        {
            Resident.IdListResident.Refresh();
            return true;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IdListQueryModel[] GetAll()
        {
            return Resident.IdListResident.GetAllData();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetById")]
        public IdListQueryModel GetById(int id)
        {
            return Resident.IdListResident.GetDataById(id);
        }
    }
}
