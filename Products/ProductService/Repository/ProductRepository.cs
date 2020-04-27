using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;

        public ProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public void AddProducts(Products prodobj)
        {
            _context.Add(prodobj);
            _context.SaveChanges();
        }

        

        public void DeleteProduct(string prodid)
        {
            Products prodobj = _context.Products.Find(prodid);
            _context.Remove(prodobj);
            _context.SaveChanges();
        }

        public void UpdateProducts(Products prodobj)
        {
            _context.Products.Update(prodobj);
            _context.SaveChanges();
        }

        

        public List<Products> ViewProducts()
        {
            return _context.Products.ToList();

        }

        
    }
}
