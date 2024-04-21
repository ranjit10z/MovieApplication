using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie:BaseEntity
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Gnere { get; set; }

    }
}
