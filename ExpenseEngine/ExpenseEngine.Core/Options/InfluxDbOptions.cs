using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Options
{
    public class InfluxDbOptions
    {
        public const string InfluxDb = "InfluxDB";

        public string Token { get; set; } =string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
