﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonApp.API.Data;

namespace PokemonApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ValuesController(AppDataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
