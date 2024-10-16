using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Models
{
    public class Card
    {
        public required int Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
    }
}
