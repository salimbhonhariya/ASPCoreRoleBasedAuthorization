using System;
using System.Collections.Generic;
using System.Linq;


namespace TodoCoreAPI.Models
{
    public class TodoItem
    {


        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }




}