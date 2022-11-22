using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSleep.Models
{
    public class LiveData
    {
        public string CurrentTemp { get; set; }
        public string AvgTemp { get; set; }
        public string? MaxTemp { get; set; } = "";
        public string? MinTemp { get; set; } = "";
    }
}
