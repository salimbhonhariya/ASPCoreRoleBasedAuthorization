using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCoreAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoCoreAPI
{
    [Route("api/[controller]")]
    public class TodoCoreAPIController : Controller
    {
        public ITodoRepository TodoItems { get; set; }

        public TodoCoreAPIController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
       

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.Update(item);
            return new NoContentResult();
        }

    }
}
