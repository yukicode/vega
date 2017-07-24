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
    public class MakerController: Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public MakerController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MakerResource>> GetAll()
        {
            var makers = await _context.Makers.Include(m => m.Models).ToListAsync();
            return _mapper.Map<List<Maker>, List<MakerResource>>(makers);
        }
    }
}