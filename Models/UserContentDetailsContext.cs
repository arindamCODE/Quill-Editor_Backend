using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models
{
    public class UserContentDetailsContext : DbContext
    {
        public UserContentDetailsContext(DbContextOptions<UserContentDetailsContext> options)
            : base(options)
        {

        }

        public DbSet<UserContentDetails> UserContentDetails { get; set; }

    }
}