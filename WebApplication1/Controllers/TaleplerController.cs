using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Talepler;
using System.Net.Http;
using WebApplication1.DTOs.Talepler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using System.Text.Json;
using WebApplication1.Repository;
namespace WebApplication1.Controllers
{
    public class TaleplerController : Controller
    {
        private readonly ITaleplerRepository _taleplerRepository;
        public TaleplerController(ITaleplerRepository taleplerRepository)
        {
            _taleplerRepository = taleplerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TalepListesi()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Talep talep)
        {
            var result = await _taleplerRepository.Create(talep);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTalepler()
        {
            var result = await _taleplerRepository.GetTalepler();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var result = await _taleplerRepository.GetComments();
            return Ok(result);
        }
       
    }
}
