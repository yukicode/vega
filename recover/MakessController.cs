using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using System.Linq;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    public class MakesController: Controller {
        private readonly CarContext _context;
        
        public MakesController(CarContext context)
        {
            _context = context;

            if(_context.Makers.Count() == 0)
            {
                _context.Makers.Add( new Maker {Name = "Maker1"} );
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Maker> GetAll() {
            return _context.Makers.ToList();
        }

        [HttpGet("{id}", Name="GetMaker")]
        public IActionResult GetById(long id) 
        {
            var maker = _context.Makers.FirstOrDefault(m => m.Id == id);

            if(maker == null)
            {
                return NotFound();
            }

            return new ObjectResult(maker);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Maker maker)
        {
            if (maker == null)
            {
                return BadRequest();
            }

            _context.Makers.Add(maker);
            _context.SaveChanges();

            return CreatedAtRoute("GetMaker", new {id = maker.Id}, maker);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Maker maker)
        {
            if (maker == null || maker.Id != id)
            {
                return BadRequest();
            }

            var oldMaker = _context.Makers.FirstOrDefault( m => m.Id == id );
            if (oldMaker == null) 
            {
                return NotFound();
            }

            oldMaker.Name = maker.Name;
            oldMaker.Models = maker.Models;

            _context.Makers.Update(oldMaker);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }

}