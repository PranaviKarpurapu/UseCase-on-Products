using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repository;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _prodrepo;

        public ProductController(IProductRepository prodrepo)
        {
            _prodrepo = prodrepo;
        }

        [HttpPost]
        [Route("AddProducts")]
        public IActionResult AddProducts(Products prodobj)
        {
            try
            {
                _prodrepo.AddProducts(prodobj);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ViewProducts")]
        public IActionResult ViewProducts()
        {
            try
            {

                return Ok(_prodrepo.ViewProducts());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePrduct")]
        public IActionResult UpadteProducts(Products prodobj)
        {
            try
            {
                _prodrepo.UpdateProducts(prodobj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteProduct/{prodid}")]
        public IActionResult DeleteProduct(string prodid)
        {
            try
            {
                _prodrepo.DeleteProduct(prodid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
    }
}