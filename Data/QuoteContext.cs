using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace Data
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {

        }

        public DbSet<Quote> Qoutes { get; set; }
    }
}
