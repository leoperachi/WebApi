﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null !;
    }
}
