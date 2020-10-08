using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace todoapp
{
    public class TodoLists : IEnumerable
    {
        private List<TodoList> todoLists;

        public int Count { get => todoLists.Count; }

        public TodoLists(bool addSampleLists = false)
        {
            todoLists = new List<TodoList>();
            if (addSampleLists) 
                AddSampleLists();
        }

        private void AddSampleLists()
        {
            todoLists.Add(new TodoList("Grocery Store", true));
            todoLists.Add(new TodoList("Costco"));
        }

        public TodoList this[int index]
        {
            get => todoLists[index];
            set => todoLists[index] = value;
        }

        public bool HasLists() {
            return (todoLists.Count > 0);
        }

        public bool DeleteList(TodoList obj)
        {
            var result = false;
            if (obj is TodoList)
            {
                result = todoLists.Remove(obj);
            }
            return result;
        }

        public TodoList GetListByTitle(string title)
        {
            var result = from TodoList list in this
                        where list.Title == title
                        orderby list.Title ascending
                        select list;
            return result.DefaultIfEmpty(null).First();
        }

        public bool AddList(TodoList obj)
        {
            var result = false;
            if (obj is TodoList)
            {
                todoLists.Add(obj);
                result = true;
            }
            return result;
        }

        public IEnumerator GetEnumerator() => new MyEnumerator<TodoList>(todoLists);

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (var i = 0; i < todoLists.Count; i++)
            {
                var incompleteItems = from TodoItem item in todoLists[i]
                                    where item.IsComplete == false
                                    select item;
                output.AppendLine($"{i}) " + todoLists[i].Title + $" (incomplete items: {incompleteItems.Count()})");
            }
            return output.ToString();
        }
    }
}