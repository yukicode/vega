using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using System.Linq;

namespace Vega.Controllers{
    [Route("api/[controller]")]
    public class FeaturesController: Controller 
    {
        private readonly CarContext _context;
        public FeaturesController(CarContext context)
        {
            _context = context;

            if(_context.Features.Count() == 0)
            {
                _context.Features.Add( new Feature {Name = "Feature_1"});
                 _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Feature> GetAll()
        {
            return _context.Features.ToList();
        }

        [HttpGet("{id}", Name="GetFeature")]
        public IActionResult GetById(long id)
        {
            var feature = _context.Features.FirstOrDefault(f => f.Id == id);
            if(feature == null)
            {
                return NotFound();
            }

            return new ObjectResult(feature);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Feature feature)
        {
            if(feature == null)
            {
                return BadRequest();
            }

            _context.Features.Add(feature);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetFeature", new { id = feature.Id }, feature );
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Feature feature)
        {
            if( feature == null || feature.Id != id)
            {
                return BadRequest();
            }

            var oldFeature = _context.Features.FirstOrDefault( f => f.Id == id);
            if( oldFeature == null)
            {
                return NotFound();
            }

            oldFeature.Name = feature.Name;
            _context.Features.Update(oldFeature);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}