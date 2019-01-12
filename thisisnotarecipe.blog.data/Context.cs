using System;
using Microsoft.EntityFrameworkCore;

namespace thisisnotarecipe.blog.data {
    public class Context : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlite("Data Source=cookbook.db");
        }
    }
}
