using AutoMapper;
using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VidllyApp.App_Start;
using VidllyApp.Dtos;
using VidllyApp.Models;
using System.Data.Entity;

namespace VidllyApp.Controllers.Api
{

    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            //_linkGenerator = new LinkGenerator();
            //_mapper = new Mapper();

        }


        public IHttpActionResult Get(string query = null)
        {
            var res = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrEmpty(query))
                res = res.Where(c => c.Name.Contains(query));



            return Ok(AutoMap.Mapper.Map<CustomerModel[]>(res.ToList()));
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customer == null)
                    return NotFound();

                return Ok(AutoMap.Mapper.Map<CustomerModel>(customer));
            } catch( Exception e)
            {
                return BadRequest();
                //StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, CustomerModel customer)
        {
            var res = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (res == null)
                return NotFound();
            //from dto to db
            try
            {
                AutoMap.Mapper.Map(customer, res);

                //_context.Customers.Update(customer);
                _context.SaveChanges();
                return Ok(AutoMap.Mapper.Map<CustomerModel>(res));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            //return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var res = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (res == null)
                return NotFound();
            //from dto to db
            try
            {
                _context.Customers.Remove(res);
                
                //_context.Customers.Update(customer);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Post(CustomerModel customer)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (cust != null)
                return BadRequest("Used Id");

            try
            {
                var custom = AutoMap.Mapper.Map<Customer>(customer);
                _context.Customers.Add(custom);
                _context.SaveChanges();
                return Created(new Uri(Request.RequestUri + "/" + custom.Id), custom);
            } catch( Exception e)
            {
                return BadRequest("Internal Error " + e.Message);
            }
        }
    }
}
