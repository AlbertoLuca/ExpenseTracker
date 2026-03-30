using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using System.Text.Json;


namespace ExpenseTracker.Services
{
    public class TransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }


        static private List<TransactionItem> transactions = new();

        public List<TransactionItem> GetAll()
        {
            
            transactions = _context.Transactions.ToList();
            if(transactions != null)
            {
                return transactions;
            }
            else
            {
                return new List<TransactionItem>();
            }
            
        }
        public void Add(TransactionItem item)
        {
            item.Id = transactions.Any() ? transactions.Max(x => x.Id) + 1 : 1;
            _context.Transactions.Add(item);
            _context.SaveChanges();
            transactions = GetAll();
        }
        public void Remove(int id)
        {
            TransactionItem trans = _context.Transactions.FirstOrDefault(x => x.Id == id);
            if(trans != null)
            {
                _context.Transactions.Remove(trans);
                _context.SaveChanges();
            }
            
        }
        public void Update(TransactionItem updateditem)
        {
            var existingItem = _context.Transactions.FirstOrDefault(x => x.Id == updateditem.Id);

            if(existingItem != null)
            {
                existingItem.Id = updateditem.Id;
                existingItem.Title = updateditem.Title;
                existingItem.IsIncome = updateditem.IsIncome;
                existingItem.Category = updateditem.Category;
                existingItem.Amount = updateditem.Amount;
                existingItem.Date = updateditem.Date;
            }
            _context.SaveChanges();
        }

        
        

    }
}
