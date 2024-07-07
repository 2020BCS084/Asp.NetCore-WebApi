using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int Id {get; set;}
        public string Symbol{get; set;}=string.Empty;
        public decimal Purchase{get; set;}
        public string CompanyName{get; set;}=string.Empty;

        [Column(TypeName ="decimal(18, 2)")]    //In database it specifies lastdiv datatype as decimal with precision of 18 and scale of 2.
        public decimal LastDiv{get; set;}
        public string Industry{get; set;}=string.Empty;
        public long MarketCap{get; set;}
       
        public List<Comment> Comments{get; set;}=new List<Comment>();

        internal object ToStockDto()
        {
            throw new NotImplementedException();
        }
    }
}