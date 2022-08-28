using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService : ISeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return;

            using (var transaction = _context.Database.BeginTransaction())
            {

                Departament firstdepartament = new Departament(1, "computers");
                Departament seconddepartament = new Departament(2, "electronics");
                Departament thirddepartament = new Departament(3, "fashion");
                Departament fourthdepartament = new Departament(4, "books");

                Seller firstseller = new Seller(1, "bill", "bill@salesweb.com", new DateTime(1955, 6, 15), 3000.00, firstdepartament);
                Seller secondseller = new Seller(2, "steve", "steve@salesweb.com", new DateTime(1958, 2, 20), 3100.00, seconddepartament);
                Seller thirdseller = new Seller(3, "elizabeth", "elizabeth@salesweb.com", new DateTime(1982, 8, 7), 3450.00, thirddepartament);

                SalesRecord firstsale = new SalesRecord(1, new DateTime(2022, 8, 13), 1474.98, SaleStatus.Billed, firstseller);
                SalesRecord secondsale = new SalesRecord(2, new DateTime(2022, 8, 10), 1500.00, SaleStatus.Billed, secondseller);
                SalesRecord thirdsales = new SalesRecord(3, new DateTime(2022, 8, 07), 1878.47, SaleStatus.Billed, thirdseller);
                SalesRecord fourthsale = new SalesRecord(4, new DateTime(2022, 7, 20), 22878.48, SaleStatus.Billed, firstseller);
                SalesRecord fifithsale = new SalesRecord(5, new DateTime(2022, 7, 13), 15789.45, SaleStatus.Billed, secondseller);

                _context.Departament.AddRange(firstdepartament, seconddepartament, thirddepartament, fourthdepartament);
                _context.Seller.AddRange(firstseller, secondseller, thirdseller);
                _context.SalesRecord.AddRange(firstsale, secondsale, thirdsales, fourthsale, fifithsale); ;

                _context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}