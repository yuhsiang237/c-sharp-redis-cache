using Microsoft.AspNetCore.Mvc;

using CacheService.Services.Redis;

namespace CacheService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly IRedis _redis;

        public SystemController(IRedis redis)
        {
            _redis = redis;
        }
        /// <summary>
        /// Get Status
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStatus")]
        public string GetStatus()
        {
            return "It works.";
        }

        /// <summary>
        /// Test Redis
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestRedis")]
        public string TestRedis()
        {
            var db = _redis.GetDatabase();
            var val = "";
            if (db.StringSet("testKey", "testValue"))
            {
                val = db.StringGet("testKey");
            }
            return val;
        }
    }
}
