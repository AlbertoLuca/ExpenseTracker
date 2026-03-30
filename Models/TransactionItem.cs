namespace ExpenseTracker.Models
{
    public class TransactionItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public decimal Amount { get; set; }
        public string Category { get; set; } = "";
        public bool IsIncome { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;

    }
}
