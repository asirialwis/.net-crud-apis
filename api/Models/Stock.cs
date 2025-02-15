using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    public class Stock
    {
        internal int id;

        public int Id { get; set; }
        public String Symbol { get; set; } = String.Empty;
        public String CompanyName { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }

        public String Industry { get; set; } = String.Empty;

        public long MarketCap { get; set; }

       public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}