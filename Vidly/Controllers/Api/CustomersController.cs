using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Vidly.Models;
using System.Data.Entity;
using Vidly.DTOs;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.Include(c => c.MembershipType).ToList());
        }
        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost] //Post /api/customers
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            

            if (customer==null)
            {
                return NotFound();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            //return customer;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer==null)
            {
                return NotFound();
            }
            dbCustomer.Name = customer.Name;
            dbCustomer.Brithdate = customer.Brithdate;
            dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            dbCustomer.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(dbCustomer);
            _context.SaveChanges();
            return Ok();
        }



    }
}
