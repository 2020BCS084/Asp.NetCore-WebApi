using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ⭐In this Dto class we just define the properties which we want to send and receive from api.
namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id {get; set;}
        public string Symbol{get; set;}=string.Empty;

         public decimal Purchase{get; set;}
        public string Industry{get; set;}=string.Empty;

        public string CompanyName{get; set;}=string.Empty;
        public long MarketCap{get; set;}
        public decimal LastDiv{get; set;}
        

        //comments  
    }
}