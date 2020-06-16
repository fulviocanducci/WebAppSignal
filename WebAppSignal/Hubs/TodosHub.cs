using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppSignal.Models;

namespace WebAppSignal.Hubs
{
    public class TodosHub : Hub
    {
        private DbaseContext Source { get; }
        public TodosHub(DbaseContext source)
        {
            Source = source;
        }

        public async Task AddServerTodo(Todo todo)
        {
            Source.Todo.Add(todo);
            await Source.SaveChangesAsync();
            await Clients.All.SendAsync("AddClientTodo");
        }

        public async Task GetServerTodo()
        {
            IEnumerable<Todo> todos = await Source
                .Todo
                .AsNoTracking()
                .ToListAsync();
            await Clients.All.SendAsync("GetClientTodo", todos);
        }
    }
}
