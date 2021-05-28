using FinanceMentor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FinanceMentor.Server.Storage;
using System;

namespace FinanceMentor.Server.Controllers
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

        /// <summary>
        /// EarningsController method added to post the user data to repository
        /// </summary>
        /// <param name="expense"></param>
        [HttpPost]
        public void Post(Expense expense)
        {
            _expenseRepository.Add(expense);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _expenseRepository.GetAll()
              .Single(item => item.Id == id);
            _expenseRepository.Remove(entity);
        }
    }
}
