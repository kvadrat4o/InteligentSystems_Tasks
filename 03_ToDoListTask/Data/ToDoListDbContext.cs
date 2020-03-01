using System;
using System.Collections.Generic;
using System.Text;
using _03_ToDoListTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _03_ToDoListTask.Data
{
    public class ToDoListDbContext : IdentityDbContext<User, UserRole, int>
    {

        public DbSet<Task> Tasks { get; set; }
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasKey(u => u.Id);

            builder.Entity<Task>()
                .HasKey(t => t.Id);

            builder.Entity<Task>()
                .HasOne(t => t.Author)
                .WithMany(a => a.Tasks)
                .HasForeignKey(fk => fk.AuthorId);
        }
    }
}
