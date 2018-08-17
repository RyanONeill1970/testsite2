using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Dto;
using AutoMapper;

namespace WebApplication1.Controllers.API
{
    public class CustomersController : ApiController
    {

        private dbgeneration _context;

        public CustomersController()
        {
            _context = new dbgeneration();

        }

        public IEnumerable<CustomerDto> GetCustomers()
        {

            return _context.GetCustomers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.GetCustomers.SingleOrDefault(c => c.CustomerId == id);
                if (customer == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }


            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.GetCustomers.Add(customer);
                _context.SaveChanges();

                customerDto.CustomerId = customer.CustomerId;

            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto );
            
            
        }






        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            
            var customerInDb = _context.GetCustomers.SingleOrDefault(c => c.CustomerId == id);


             if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

                }

        [HttpDelete]
        public void DeleteCustomer(int id)
        { 


             var customerInDb = _context.GetCustomers.SingleOrDefault(c => c.CustomerId == id);
                if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.GetCustomers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}
