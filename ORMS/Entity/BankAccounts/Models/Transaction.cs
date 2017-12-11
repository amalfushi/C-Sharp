using System;

namespace BankAccounts.Models
{
    public class Transaction: BaseEntity
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}