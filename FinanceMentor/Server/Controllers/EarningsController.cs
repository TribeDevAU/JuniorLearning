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
    public class EarningsController : ControllerBase
    {
        private readonly IRepository<Earning> _earningRepository;
        public EarningsController(IRepository<Earning> earningRepository)
        {
            _earningRepository = earningRepository;
        }
        [HttpGet]
        public IEnumerable<Earning> Get()
        {
            return _earningRepository.GetAll()
                .OrderBy(earning => earning.Date);
        }

        /// <summary>
        /// EarningsController method added to post the user data to repository
        /// </summary>
        /// <param name="earning"></param>
        [HttpPost]
        public void Post(Earning earning)
        {
            _earningRepository.Add(earning);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _earningRepository.GetAll()
              .Single(item => item.Id == id);
            _earningRepository.Remove(entity);
        }
    }
}
