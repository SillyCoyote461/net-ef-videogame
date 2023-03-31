using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VideogameContext : DbContext
{
    public DbSet<Videogame> Videogames { get; set; }
    public DbSet<SoftwareHouse> SoftwareHouse { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=True; Encrypt = false;");
    }

}

