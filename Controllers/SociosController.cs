using Microsoft.AspNetCore.Mvc;
using Socios.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ApiSocios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SociosController : ControllerBase
    {
        private const string DB_NAME = "SociosDb";
        private const string COLLECTION_NAME = "Socios";
        private readonly IMongoCollection<Socio> _socios;
        public SociosController(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(DB_NAME);

            _socios = database.GetCollection<Socio>(COLLECTION_NAME);
        }

        [HttpGet]
        public IActionResult GetSocios()
        {
            var sociosList = _socios.Find(e => true).ToList();

            return Ok(sociosList);
        }

        [HttpGet("{id}")]
        public IActionResult GetSociosById(string id)
        {

            var objectSocio = _socios.Find<Socio>(socio => socio.Id == id).FirstOrDefault();

            return Ok(objectSocio);
        }

        [HttpGet,Route("/ativos")]
        public IActionResult GetSociosAtivos()
        {
            var sociosList = _socios.Find(e => true).ToList();
            var sociosAtivos = sociosList.Where<Socio>(socio => socio.Ativo == true);

            return Ok(sociosAtivos);
        }

        [HttpGet, Route("/inativos")]
        public IActionResult GetSociosInativos()
        {
            var sociosList = _socios.Find(e => true).ToList();
            var sociosAtivos = sociosList.Where<Socio>(socio => socio.Ativo == false);

            return Ok(sociosAtivos);
        }

        [HttpPost]
        public IActionResult CreateSocio([FromBody]Socio socio)
        {
            var newSocio = new Socio(socio.Nome, socio.Telefone, socio.DataNascimento, socio.DataIngresso, socio.Ativo);

            _socios.InsertOne(newSocio);

            return Ok(newSocio);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Socio socioIn)
        {
            _socios.Find<Socio>(socio => socio.Id == id).FirstOrDefault();
            socioIn.Id = id;
            _socios.ReplaceOne(socio => socio.Id == id, socioIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _socios.Find<Socio>(socio => socio.Id == id).FirstOrDefault();
            _socios.DeleteOne(socio => socio.Id == id);

            return Ok("Removido ");
        }
    }
}
