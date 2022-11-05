﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class ReCapProjectsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProjects;Trusted_Connection=true");
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Brand> Brand { get; set; }
    }
}
