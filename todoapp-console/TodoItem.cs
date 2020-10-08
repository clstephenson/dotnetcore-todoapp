using System;

namespace todoapp
{
    public class TodoItem
    {
        public Guid Id { get; }

        public bool IsComplete { get; set; }

        public string Text { get; set; }

        public TodoItem(string text = "") {
            Id = Guid.NewGuid();
            Text = text;
            IsComplete = false;
        }

        public void ToggleComplete()
        {
            IsComplete = !IsComplete;
        }

        public override string ToString()
        {
            var complete = IsComplete ? "X" : " ";
            return $"[{complete}] - {Text}";
        }
    }
}