﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestWebApplicationMVC.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<TestWebApplicationMVC.Models.User> Users { get; set; }

        //public System.Data.Entity.DbSet<TestWebApplicationMVC.Models.User> Users { get; set; }
    }
}