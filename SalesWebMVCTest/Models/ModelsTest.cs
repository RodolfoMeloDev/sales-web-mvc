using NUnit.Framework;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMVCTest.Models
{
    [TestFixture]
    public class ModelsTest
    {
        private Department _department;
        private Seller _seller;
        private SalesRecord _salesRecord;
        [SetUp]
        public void Setup()
        {
            _department = new Department(1, "Books");
            _seller = new Seller(1, "Erick", "erick@gmail.com", new DateTime(1990, 10, 1), 3000, _department);             
            _salesRecord = new SalesRecord(1, new DateTime(2022, 4, 26), 5000, SaleStatus.Pago, _seller);

            _seller.AddSales(_salesRecord);
        }

        [Test]
        public void TestarConstrutoresSemParametros()
        {
            Department department = new Department();
            Assert.IsNotNull(department);

            Seller seller = new Seller();
            Assert.IsNotNull(seller);

            SalesRecord salesRecord = new SalesRecord();
            Assert.IsNotNull(seller);
        }
        
        [Test]
        public void TotalDeVendasCorreto()
        {
            var result = _seller.TotalSales(new DateTime(2022, 1, 1), new DateTime(2022, 12, 31));

            Assert.AreEqual(5000, result);
        }

        [Test]
        public void RemoverVenda()
        {
            _seller.RemoveSales(_salesRecord);

            Assert.IsEmpty(_seller.Sales);
        }

        [Test]
        public void TotalVendasDoDepartamento()
        {
            _department.AddSaller(_seller);            

            Assert.AreEqual(5000, _department.TotalSales(new DateTime(2022, 1, 1), new DateTime(2022, 12, 31)));
        }
    }
}