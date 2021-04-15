﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Data;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService (SalesWebMvcContext context )
        {
            _context = context; 
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Inser(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
