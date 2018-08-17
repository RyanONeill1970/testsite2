using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApplication1.Dto;
using System.Web.Http;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
    public class ProductsAPIController : ApiController
    {

        private dbgeneration _context;

        public ProductsAPIController()
        {
            _context = new dbgeneration();

        }

        public IEnumerable<ProductDto> GetProducts()
        {

            return _context.GetProducts.ToList().Select(Mapper.Map<Product, ProductDto>);

        }

        public ProductDto GetProduct(int id)
        {
            var product = _context.GetProducts.SingleOrDefault(c => c.ProductID == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Product, ProductDto>(product);
        }


        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }


            var product = Mapper.Map<ProductDto, Product>(productDto);

            _context.GetProducts.Add(product);
            _context.SaveChanges();

            productDto.ProductID = product.ProductID;

            return Created(new Uri(Request.RequestUri + "/" + product.ProductID), productDto);


        }


        // modify other tasks


        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            var productInDb = _context.GetProducts.SingleOrDefault(c => c.ProductID == id);


            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {


            var productInDb = _context.GetProducts.SingleOrDefault(c => c.ProductID == id);
            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.GetProducts.Remove(productInDb);
            _context.SaveChanges();

        }


    }
}
