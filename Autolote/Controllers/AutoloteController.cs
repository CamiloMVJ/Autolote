using Autolote.Data;
using Autolote.Models;
using Autolote.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoloteController : ControllerBase
    {
        private readonly AutoloteContext _db;
        private readonly ILogger<AutoloteController> _logger;


        public AutoloteController(ILogger<AutoloteController> logger, AutoloteContext db)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        //[Route("GetCarros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CarroDTO>>> GetCarros()
        {
            _logger.LogInformation("Solicitando lista de carros");
            return Ok(await _db.Carros.ToListAsync());
        }

        [HttpPost("InsertarCliente/{Nombre}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult PostCliente(string Nombre)
        {
            if (Nombre == "" || Nombre == null)
            {
                _logger.LogError("Nombre no valido");
                return BadRequest();
            }

            _db.Clientes.Add(new Models.Cliente()
            {
                ClienteNombre = Nombre
            });
            _db.SaveChanges();
            _logger.LogInformation("Cliente creado con exito");
            return Ok();
        }

        [HttpPost("InsertarCarro/{Marca}/{Precio}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult PostCarro(string Marca, decimal Precio)
        {
            if ((Marca == "" || Marca == null) || (Precio == null))
            {
                _logger.LogError("Post cancelado");
                return BadRequest();
            }

            _db.Carros.Add(new Models.Carro()
            {
                Marca = Marca,
                Precio = Precio
            });
            _db.SaveChanges();
            _logger.LogInformation("Carro creado con exito");
            return Ok();
        }

        [HttpPost("InsertarRegistro/{IdCarro}/{IdCliente}/{CantidadDePagos}/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PostRegistro(int IdCarro, int IdCliente, int CantidadDePagos)
        {
            try
            {
                var carro = _db.Carros.Find(IdCarro);
                var cliente = _db.Clientes.Find(IdCliente);
                if (carro == null || cliente == null || CantidadDePagos == 0)
                {
                    _logger.LogError("Error en la solicitud");
                    return NotFound();
                }
                var registro = new Registro(cliente, carro);
                registro.CalcularCouta(CantidadDePagos);
                _db.Registros.Add(registro);
                _db.SaveChanges();
                _logger.LogInformation("Registro creado con exito");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("No se pudo completar el POST, mensaje de error: " + ex.Message);
                return BadRequest();
            }
        }
    }
}
