using System;
using Xunit;
using todoapp;

namespace todoapp_console.tests
{
    public class TodoLists_Tests
    {
        [Fact]
        public void Add_SingleListToEmptyCollection_ReturnsCountOfOne()
        {
            TodoLists todoLists = CreateDefaultTodoListCollection();
            todoLists.AddList(new TodoList());

            var actual = todoLists.Count;

            Assert.Equal(1, actual);
        }

        private TodoLists CreateDefaultTodoListCollection()
        {
            return new TodoLists();
        }
    }

}
