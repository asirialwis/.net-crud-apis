using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
          public int Id { get; set; }
        public String Title { get; set; } = String.Empty;

        public String Content { get; set; } = String.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
         
         public int? StockId { get; set; }
        //Navigation property
        
    }
}