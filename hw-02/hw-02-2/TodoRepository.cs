using System;
using System.Collections.Generic;
using System.Linq;
using raupjc_hw1;

namespace hw_02_4
{
    /// <summary >
    /// Class  that  encapsulates  all  the  logic  for  accessing  TodoTtems.
    /// </summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository  does  not  fetch  todoItems  from  the  actual  database ,
        /// it uses in  memory  storage  for  this  excersise.
        ///  </summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            //  Shorter  way to  write  this in C# using ??  operator:
            // x ?? y => if x is not null , expression  returns x. Else it will return y.
            //  _inMemoryTodoDatabase = initialDbState  ?? new List <TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {   
            
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (Get(todoItem.Id) != null)
            {
                throw new DuplicateTodoItemException("duplicate  id: {"+todoItem.Id+"}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public class DuplicateTodoItemException : Exception
        {
            public DuplicateTodoItemException(string duplicateIdId)
            { 
                
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item= _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));
            return item != null && _inMemoryTodoDatabase.Remove(item);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);
            Add(todoItem);
            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {   
           
            TodoItem item = _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));
            return item != null && item.MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i=>i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction.Invoke).ToList();
        }
    }
}