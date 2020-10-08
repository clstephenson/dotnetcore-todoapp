using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace todoapp
{
    public class TodoList : IEnumerable
    {
        private List<TodoItem> todoItems;

        public string Title { get; set; }

        public int Count { get => todoItems.Count; }

        public TodoList(string title = "", bool addSampleEntries = false)
        {
            Title = title;
            todoItems = new List<TodoItem>();
            if (addSampleEntries) 
                AddSampleEntries();
        }

        private void AddSampleEntries()
        {
            todoItems.Add(new TodoItem("Milk"));
            todoItems.Add(new TodoItem("Eggs"));
            todoItems.Add(new TodoItem("Yogurt"));
            todoItems.Add(new TodoItem("Apples"));
            todoItems.Add(new TodoItem("Oranges"));
        }

        public TodoItem this[int index]
        {
            get => todoItems[index];
            set => todoItems[index] = value;
        }

        public bool HasItems() {
            return (todoItems.Count > 0);
        }

        public bool DeleteItem(TodoItem obj)
        {
            var result = false;
            if (obj is TodoItem)
            {
                result = todoItems.Remove(obj);
            }
            return result;
        }

        public TodoItem GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(TodoItem obj)
        {
            var result = false;
            if (obj is TodoItem)
            {
                todoItems.Add(obj);
                result = true;
            }
            return result;
        }

        public void ClearAll()
        {
            todoItems.Clear();
        }

        public IEnumerator GetEnumerator() => new MyEnumerator<TodoItem>(todoItems);

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Title: {Title}");
            for (var i = 0; i < todoItems.Count; i++)
            {
                output.AppendLine($"{i}) " + todoItems[i].ToString());
            }
            return output.ToString();
        }
    }
}