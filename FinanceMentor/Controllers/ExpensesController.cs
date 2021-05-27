using FinanceMentor.Shared;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinanceMentor.Components;
using FinanceMentor.Server.Storage;

namespace FinanceMentor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expenseRepository;

        public ExpensesController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseRepository.GetAll()
                .OrderBy(expense => expense.Date);
        }

        [HttpPost]
        public void Post(Expense expense)
        {
            _expenseRepository.Add(expense);
        }

    }
}