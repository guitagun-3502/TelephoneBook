using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TelephoneBook.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList StructuralSubdivisions { get; set; }
        public string SearchString { get; set; }
    }
}