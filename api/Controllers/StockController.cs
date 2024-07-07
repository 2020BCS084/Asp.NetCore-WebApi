using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using api.Dtos;
using api.Mappers;
using api.Dtos.Stock;
using Microsoft.EntityFrameworkCore;               //it is neccessary for async await.




namespace api.Controllers
{
    [Route("api/stock")]            //this will be the route after the base url for the api's of StockController.
    [ApiController]  
    public class StockController:ControllerBase   //necessary to inherit this ControllerBase class.
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context){
            _context=context;
        }

        //following is a example of how to write method without async-await.
        //  [HttpGet]
        // public IActionResult GetAll(){                 //here StockMappers is a class which consist of the ToStockDto method.
        //     var stocks=_context.Stocks.ToList();  //tolist becuase it converts the sql object into the list & list to stockdto.
        //     var stockDto=stocks.Select(s=>StockMappers.ToStockDto_(s));
        //     return Ok(stocks);
        // }

        //if we are using async-await it is necessary to return Task<>. else error. means we have to wrap our return type inside Task<>.

        [HttpGet]
        public async Task<IActionResult> GetAll(){                 //here StockMappers is a class which consist of the ToStockDto method.
            var stocks=await _context.Stocks.ToListAsync();  //tolist becuase it converts the sql object into the list & list to stockdto.
            var stockDto=stocks.Select(s=>StockMappers.ToStockDto_(s));
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock=await _context.Stocks.FindAsync(id);
            if(stock==null){
                return NotFound();
            }
            return Ok(StockMappers.ToStockDto_(stock));    
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest stockDto){
            var stockModel =StockMappers.ToStockFromCreateDTO(stockDto);
           await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id=stockModel.Id}, stockModel.ToStockDto());
        }


        [HttpPut]
        [Route("{id}")]
        
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto UpdateDto){

            var stockModel=await _context.Stocks.FirstOrDefaultAsync(val=>val.Id==id);

            if(stockModel==null){
                return NotFound();
            }

            stockModel.Symbol=UpdateDto.Symbol;
            stockModel.CompanyName=UpdateDto.CompanyName;
            stockModel.Industry=UpdateDto.Industry;
            stockModel.Purchase=UpdateDto.Purchase;
            stockModel.LastDiv=UpdateDto.LastDiv;
            stockModel.MarketCap=UpdateDto.MarketCap;

           await _context.SaveChangesAsync();

            return Ok(StockMappers.ToStockDto_(stockModel));
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel=_context.Stocks.FirstOrDefault(val=>val.Id==id);
            if(stockModel==null){
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);                                    //we dont use await for remove i.e delete.
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}