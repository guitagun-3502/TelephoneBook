//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelephoneBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string Position { get; set; }
        public string StructuralSubdivision { get; set; }
        public ICollection<Telephone> Telephones { get; set; }
        public User()
        {
            Telephones = new List <Telephone>();
        }
    }
}