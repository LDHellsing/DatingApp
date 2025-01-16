using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// Concepto de constructor primario es un constructor simple que recibe un objeto options y se lo pasa a la super clase DbContext
public class DataContext(DbContextOptions options) : DbContext(options)
{
    // Basicamente EntityFramework va a crear una tabla "Users" los cuales son objetos del tipo AppUser
    public DbSet<AppUser> Users { get; set; }
}
