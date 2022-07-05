using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using APIProject.Models;
using APIProject.Repository;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using APIProject.Filters;

namespace APIProject.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T> : ControllerBase where T : class
    {
        protected IRepository<T> repository;

        public BaseController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        // GET: api/<Controller>
        [HttpGet]
        public ICollection<T> Get()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return repository.GetAll();
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return null;
            
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public T GetById(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = repository.GetById(id);

                    if (obj == null)
                    {
                        return null;
                    }
                    return obj;
                }
                catch (NullReferenceException)
                {
                    return null;
                }    
            }
            return null;


        }

        // PUT: api/<Controller>/5

        [HttpPut("{id}")]
        public string Put([FromBody] T obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var objToUpdate = repository.Update(obj);
                    return "The data has been updated";
                }
                catch (NullReferenceException)
                {
                    return "Updation failed/ Object not found";
                }
            }
            
            return "Updation failed/ Object not found";
        }

        // POST: api/<Controller>

        [HttpPost]
        public string Add(T obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var objToAdd = repository.Add(obj);
                    return "The data has been inserted";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            
            return "Insertion failed";
        }

        // DELETE: api/<Controller>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Delete(id);
                    return "The data has been deleted";
                }
                catch (NullReferenceException)
                {
                    return "Object not found";
                }
                
            }
            return "Object not found";

        }
    }
}
