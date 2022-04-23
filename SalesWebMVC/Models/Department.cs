using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter no mínimo {2} e no máxima {1} caracteres")]
        [Display(Name = "Nome")]
        public string  Name { get; set; }
        public ICollection<Seller> Sellers { get; set; }  = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
