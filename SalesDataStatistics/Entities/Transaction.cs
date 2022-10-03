using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDataStatistics.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int ReceiptNumber { get; set; }
        public int StoreID { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalItems { get; set; }
        public decimal TotalAmount { get; set; }


    }
}
