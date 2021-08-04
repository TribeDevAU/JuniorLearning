﻿using FinanceMentor1.Server.Storage;
using FinanceMentor1.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceMentor1.Server.Controllers
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
            return _earningRepository.GetAll().OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post(Earning earning)
        {
            _earningRepository.Add(earning);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var entity = _earningRepository.GetAll().Single(item => item.ID == id);
            _earningRepository.Remove(entity);
        }

    }
}
