using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using CacheService.Services.Redis;
using CacheService.Services.Resident.Models;

namespace CacheService.Services.Resident
{
    public class IdListResident : IResident
    {
        private readonly IRedis _redis;
        private readonly string _cachaName = nameof(IdListResident);

        private DateTime? _dataTime;
        private string ParseCacheIdKey(int Id) => $"{_cachaName}-Id:{Id}";

        /// <summary>
        /// Constructor
        /// </summary>
        public IdListResident(IRedis redis)
        {
            _redis = redis;
        }

        /// <inherdoc />
        public void Refresh()
        {
            var db = _redis.GetDatabase();
            var data = GetLatestData();
            db.StringSet($"{_cachaName}", JsonConvert.SerializeObject(data));
            foreach (var item in data)
                db.StringSet($"{ParseCacheIdKey(item.Id)}", JsonConvert.SerializeObject(item));

            _dataTime = DateTime.Now;
        }

        /// <summary>
        /// Get Latest Data
        /// Note : You can adjust this function and get data from your database.
        /// </summary>
        /// <returns></returns>
        private IdListQueryModel[] GetLatestData()
        {
            var data = new List<IdListQueryModel>();
            var rand = new Random();

            for (int i = 1; i < 3000; i++)
                data.Add(new IdListQueryModel
                {
                    Id = i,
                    Remark = $"Remark:{rand.Next(100, 999)}",
                });

            return data.ToArray();
        }

        /// <summary>
        /// GetDataById
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>IdListQueryModel</returns>
        public IdListQueryModel GetDataById(int Id)
        {
            var db = _redis.GetDatabase();
            if (_dataTime == null)
                Refresh();

            return JsonConvert.DeserializeObject<IdListQueryModel>(db.StringGet(ParseCacheIdKey(Id)));
        }

        /// <summary>
        /// GetAllData
        /// </summary>
        /// <returns>IdListQueryModel[]</returns>
        public IdListQueryModel[] GetAllData()
        {
            var db = _redis.GetDatabase();
            if (_dataTime == null)
                Refresh();

            return JsonConvert.DeserializeObject<IdListQueryModel[]>(db.StringGet($"{_cachaName}"));
        }
    }
}
