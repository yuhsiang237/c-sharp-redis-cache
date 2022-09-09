using CacheService.Services.Redis;

namespace CacheService.Services.Resident
{
    /// <summary>
    /// Resident Service
    /// </summary>
    public class Resident
    {
        private static IdListResident _idListResident;
        private static IRedis _redis;
        private static bool _hasInstance = false;

        public static void InitInstance()
        {
            if (!_hasInstance)
            {
                _redis = new Redis.Redis();
                _idListResident = new IdListResident(_redis);
                _hasInstance = true;
            }
        }

        /// <summary>
        /// IdListResident
        /// </summary>

        public static IdListResident IdListResident
        {
            get
            {
                InitInstance();
                return _idListResident;
            }
        }


    }
}
