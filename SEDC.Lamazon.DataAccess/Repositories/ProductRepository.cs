﻿using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(LamazonDbContext context) : base(context) { }
        
        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public int Insert(Product entity)
        {
            _context.Products.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Product entity)
        {
            _context.Products.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return -1;

            _context.Products.Remove(product);
            return _context.SaveChanges();
        }
    }
}
