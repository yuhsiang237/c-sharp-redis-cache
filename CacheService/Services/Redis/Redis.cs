using System.IO;

using Microsoft.Extensions.Configuration;
using StackExchange.Redis;


namespace CacheService.Services.Redis
{
    public class Redis : IRedis
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        /// <summary>
        /// Constructor
        /// </summary>
        public Redis()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectStr = config["Redis:DBConnection"];
            _redis = ConnectionMultiplexer.Connect(connectStr);
            _db = _redis.GetDatabase();
        }

        /// <inheritdoc/>
        public IDatabase GetDatabase() => _db;
    }
}
