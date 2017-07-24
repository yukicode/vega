using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Vega.Models;
using Vega.Presistence;
using AutoMapper;
using Vega.Controllers.Resources;

namespace Vega.Controllers 
{
    [Route("api/[controller]")]
    public class FeatureController: Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public FeatureController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FeatureResource>> GetAll()
        {
            var features = await _context.Features.ToListAsync();
            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}