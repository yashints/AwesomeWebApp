using AwesomeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwesomeWebApp.Controllers
{
    public class TodoController : ApiController
    {
        static List<Todo> todos;

        static TodoController()
        {
            // Not threadsafe 
            todos = new List<Todo>();
            todos.Add(new Todo { Id = 1, AssignedTo = "Mohit", Owner = "Cory", Title = "Clean the toilet", Description = "It's dirty!" });
            todos.Add(new Todo { Id = 2, AssignedTo = "Yochay", Owner = "Cory", Title = "Clean the floor", Description = "It's dirty!" });
            todos.Add(new Todo { Id = 3, AssignedTo = "Nir", Owner = "Cory", Title = "Make the bed", Description = "It's messy!" });
            todos.Add(new Todo { Id = 4, AssignedTo = "Vlad", Owner = "Cory", Title = "Do the dishes", Description = "They're dirty!" });
            todos.Add(new Todo { Id = 5, AssignedTo = "Stephen", Owner = "Cory", Title = "Cook the food", Description = "I'm hungry!" });
        }

        // GET: api/Todo
        public IEnumerable<Todo> Get()
        {
            return todos;
        }

        // GET: api/Todo/5
        public Todo Get(int id)
        {
            return todos.Find(m => m.Id == id);
        }

        // POST: api/Todo
        public void Post([FromBody]Todo value)
        {
            value.Id = todos.Max(m => m.Id) + 1;
            todos.Add(value);
        }

        // PUT: api/Todo/5
        public void Put(int id, [FromBody]Todo value)
        {
            if (todos.Find(m => m.Id == value.Id) != null)
            {
                todos.RemoveAll(m => m.Id == value.Id);
                todos.Add(value);
            }
        }

        // DELETE: api/Todo/5
        public void Delete(int id)
        {
            todos.RemoveAll(m => m.Id == id);
        }
    }
}
