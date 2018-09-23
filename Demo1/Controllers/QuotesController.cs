using Data;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Controllers
{
    [Route("api/quotes")]
    public class QuotesController : Controller
    {

        private readonly QuoteContext _context;

        //Whatever is passed in will automatically be instantiated
        public QuotesController(QuoteContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public void AddQuote([FromBody] Quote quote)
        {
            _context.Qoutes.Add(quote);
            _context.SaveChanges();
        }

        [HttpGet("random")]
        public Quote GetRandomQuote()
        {
            var rng = new Random();
            int randnum = rng.Next(_context.Qoutes.Count());
            return _context.Qoutes.ToArray()[randnum];
        }

        [HttpGet("")]
        public IEnumerable<Quote> GetAllQuotes()
        { 
            return _context.Qoutes;
        }


    }
}
