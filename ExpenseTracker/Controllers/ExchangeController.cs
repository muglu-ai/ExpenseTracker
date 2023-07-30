using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using ExpenseTracker.Models;



namespace ExpenseTracker.Controllers
{
    public class ExchangeController : Controller
    {


        public IActionResult Index()
        {
            var model = new ExchangeRate
            {
                Amount = 0 // Set your default amount here
            };

            var currencyOptions = new List<CurrencyOption>
            {
                new CurrencyOption { Text = "United States Dollar", Value = "USD" },
                new CurrencyOption { Text = "Indian Rupee", Value = "INR" },
                new CurrencyOption { Text = "Euro", Value = "EUR" },
                new CurrencyOption { Text = "British Pound Sterling", Value = "GBP" },
                new CurrencyOption { Text = "Canadian Dollar", Value = "CAD" },
                new CurrencyOption { Text = "Japanese Yen", Value = "JPY" }
            };
            // Add more options as needed

            ViewBag.CurrencyOptions = currencyOptions;
            return View(model);
        }

    }
}