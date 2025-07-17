using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing.Models;


namespace Testing.Data
{
    public class CalculatorDBContext : DbContext
    {
        public CalculatorDBContext() { }

        public CalculatorDBContext(DbContextOptions<CalculatorDBContext> options) : base(options) { }

        public DbSet<CalculatorEntitiy> CalculatorEntitiys { get; set; }


    }
}
