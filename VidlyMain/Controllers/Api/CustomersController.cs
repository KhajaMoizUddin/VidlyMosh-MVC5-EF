using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VidlyMain.Dtos;
using VidlyMain.Models;

namespace VidlyMain.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly MyDbContext _dbContext;

        public CustomersController()
        {
            this._dbContext = new MyDbContext();
        }

        //GET api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return this._dbContext.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //GET api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = this._dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        //POST api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            this._dbContext.Customers.Add(customer);
            this._dbContext.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        //PUT api/customers/1

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = this._dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb== null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            

            this._dbContext.SaveChanges();
        }

        //DELETE /api/customers/1

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this._dbContext.Customers.Remove(customerInDb);
            this._dbContext.SaveChanges();
        }

        
    }
}
