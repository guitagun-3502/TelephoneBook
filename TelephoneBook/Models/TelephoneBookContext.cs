using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TelephoneBook.Models
{
    public class TelephoneBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
    }
}