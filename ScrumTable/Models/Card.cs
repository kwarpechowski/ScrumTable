using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTable.Models
{
    class Card
    {
        public int CardId { get; set; }
        public Project project { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Category { get; set; }
    }
}
