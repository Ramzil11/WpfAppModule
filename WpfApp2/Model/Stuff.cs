using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    class Stuff
    {
        public string? stuffId { get; set; }
        public required string name { get; set; }
        public required string surname { get; set; }
        public required string patrpatronymic { get; set; }
        public required string login { get; set; }
        public required string password { get; set; }
        public required string profilId { get; set; }
        public required string stratDate { get; set; }
        public required string endDate { get; set; }
    }
}
