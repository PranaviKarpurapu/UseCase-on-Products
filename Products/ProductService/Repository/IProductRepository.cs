using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public interface IProductRepository
    {
        void AddProducts(Products prodobj);

        List<Products> ViewProducts();

        public void UpdateProducts(Products prodobj);

        public void DeleteProduct(string prodid);
    }
}
