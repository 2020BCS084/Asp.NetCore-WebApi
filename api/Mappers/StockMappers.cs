using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Google.Protobuf.Reflection;


namespace api.Mappers
{
    public static class StockMappers
    {
        //for converting normal object to dto.
        //Syntax of following:
        //public static dto_classname mapper_method_name(this class_name_whoseProperties_to_map var_name){}  
        public static StockDto ToStockDto_(this Stock stockModel){ //ToStockDto_ is used to convert the stock object to stockdto object.
            return new StockDto{
                Id=stockModel.Id,
                Symbol=stockModel.Symbol,
                CompanyName=stockModel.CompanyName,
                Purchase=stockModel.Purchase,
                //here excluding company name, last div and comments .
                LastDiv=stockModel.LastDiv,
                Industry=stockModel.Industry,
                MarketCap=stockModel.MarketCap
            };
        }

        //for converting dto object to normal object
        public static Stock ToStockFromCreateDTO(this CreateStockRequest stockDto){

            return new Stock{
                Symbol=stockDto.CompanyName,
                CompanyName=stockDto.CompanyName,
                Purchase=stockDto.Purchase,
                LastDiv=stockDto.LastDiv,
                Industry=stockDto.Industry,
                MarketCap=stockDto.MarketCap
            };
        }


        public static UpdateStockRequestDto UpdateStockDto(this Stock stockModel){

            return new UpdateStockRequestDto{
                Symbol=stockModel.CompanyName,
                CompanyName=stockModel.CompanyName,
                Purchase=stockModel.Purchase,
                LastDiv=stockModel.LastDiv,
                Industry=stockModel.Industry,
                MarketCap=stockModel.MarketCap
        };
        }
    }
}