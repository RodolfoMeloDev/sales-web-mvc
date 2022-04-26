using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Total")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        [Display(Name = "Vendedor")]
        public Seller Seller{ get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amout, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amout;
            Status = status;
            Seller = seller;
        }
    }
}
