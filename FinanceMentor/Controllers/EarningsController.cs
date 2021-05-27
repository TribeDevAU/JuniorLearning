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

        [HttpPost]
        public void Post(Earning earning)
        {
            _earningRepository.Add(earning);
        }

    }
}