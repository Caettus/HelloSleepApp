using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSleep.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string? Datum { get; set; }
        public string? Temperatuur { get; set; }
        public string? Hartslag { get; set; }
        public string? Slapen { get; set; }
        public string? Wakker { get; set; }                  
    }
}
