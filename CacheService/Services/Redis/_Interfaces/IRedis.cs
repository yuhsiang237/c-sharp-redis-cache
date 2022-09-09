using StackExchange.Redis;

namespace CacheService.Services.Redis
{
    public interface IRedis
    {
        /// <summary>
        /// Get Redis Database
        /// </summary>
        /// <returns>IDatabase</returns>
        public IDatabase GetDatabase();
    }
}
