using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository:IStockRepository
    {
        private readonly ApplicationDbContext _context;
        
        public StockRepository(ApplicationDbContext context, IStockRepository StockRepo){
            _context=context;
        }
        
        public Task<List<Stock>> GetAllAsync()
        {
           return _context.Stocks.ToListAsync();
        }


    }
}