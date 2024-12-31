using StackExchange.Redis;

namespace Caching
{
    public class Redis
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public Redis(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public void SetValue(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.StringSet(key, value);
        }

        public string GetValue(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return db.StringGet(key);
        }
    }
}