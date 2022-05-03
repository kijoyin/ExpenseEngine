using ExpenseEngine.Core.Options;
using InfluxDB.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Services
{
    public class InfluxDBService
    {
        private readonly InfluxDbOptions _dbOptions;

        public InfluxDBService(IOptions<InfluxDbOptions> options)
        {
            _dbOptions= options.Value;
        }

        public void Write(Action<WriteApi> action)
        {
            using var client = InfluxDBClientFactory.Create(_dbOptions.Url, _dbOptions.Token);
            using var write = client.GetWriteApi();
            action(write);
        }

        public async Task<T> QueryAsync<T>(Func<QueryApi, Task<T>> action)
        {
            using var client = InfluxDBClientFactory.Create(_dbOptions.Url, _dbOptions.Token);
            var query = client.GetQueryApi();
            return await action(query);
        }
    }
}
