using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTracker.Models
{
    public class ExchangeRate
    {
        public int Amount { get; set; }
        public string ConvertedAmount { get; set; }
        
        [Required(ErrorMessage = "Please select a currency From listed to side column.")]
        public string FromCurrency { get; set; }
        
        [Required(ErrorMessage = "Please select a currency From listed to side column.")]
        public string ToCurrency { get; set; }
        public List<CurrencyOption> CurrencyOptions { get; set; }
    }
    public class CurrencyOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}