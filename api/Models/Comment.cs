using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Title { get; set; } = String.Empty;

        public String Content { get; set; } = String.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
         
         public int? StockId { get; set; }
        //Navigation property
        public Stock? stock { get; set; }

        
    }
}