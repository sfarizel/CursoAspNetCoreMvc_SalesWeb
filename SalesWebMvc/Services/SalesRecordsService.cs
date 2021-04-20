using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //Instancia os dados IQueryable
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                //Adiciona data minina se existir    
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                //Adiciona data maxina se existir
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)  //Inclusão do objeto Seller
                .Include(x => x.Seller.Department) //Inclusão do objeto Departamento do Seller
                .OrderByDescending(x => x.Date) //Ordena descrescente por data
                .ToListAsync();
        } 
    }
}
