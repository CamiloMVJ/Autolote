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

        [HttpGet("Lista/{Tipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetLista(string Tipo)
        {
            _logger.LogInformation("Solicitando lista de " + Tipo);
            switch (Tipo.ToLower())
            {
                case "vehiculo":
                    return Ok(await _db.Vehiculos.ToListAsync());
                case "cliente":
                    return Ok(await _db.Clientes.ToListAsync());
                default:
                    return BadRequest();
            }
        }

        [HttpGet]
        [Route("RegistroCredito")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRegistrosCredito()
        {
            _logger.LogInformation("Solicitando lista de registro creditos");
            return Ok(await _db.RegistrosCredito.ToListAsync());
        }

        [HttpGet]
        [Route("RegistroContado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRegistrosContado()
        {
            _logger.LogInformation("Solicitando lista de registro contado");
            return Ok(await _db.RegistrosContado.ToListAsync());
        }

        [HttpPost]
        [Route("AgregarCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> PostCliente([FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Nombre no valido");
                return BadRequest();
            }

            if (await _db.Clientes.FindAsync(cliente.CedulaId) != null)
            {
                ModelState.AddModelError("Nombre Existe", "!La cedula ingresada ya existe en nuesta base de datos¡");
                return BadRequest(ModelState);
            }
            if (cliente == null)
                return BadRequest(cliente);

            _db.Clientes.Add(new Cliente()
            {
                NombreCliente = cliente.NombreCliente,
                CedulaId = cliente.CedulaId,
                Direccion = cliente.Direccion,
                NumeroTelfono = cliente.NumeroTelfono,
                Email = cliente.Email
            });
            _db.SaveChanges();
            _logger.LogInformation("Cliente creado con exito");
            return Ok();
        }

        [HttpPost("AgregarVehiculo/{Chasis}/{Marca}/{Precio}/{Estado}/{AñoFab}/{Stock}/{Color}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult PostCarro(string Chasis, string Marca, decimal Precio, string Estado, int AñoFab, int Stock, string Color)
        {
            if ((Marca == "" || Marca == null) || (Precio == null))
            {
                _logger.LogError("Post cancelado");
                return BadRequest();
            }

            _db.Vehiculos.Add(new Models.Vehiculo()
            {
                Chasis = Chasis,
                Marca = Marca,
                Precio = Precio,
                Estado = Estado,
                AñoFab = AñoFab,
                Stock = Stock,
                Color = Color
            });
            _db.SaveChanges();
            _logger.LogInformation("Vehiculo ingresado con exito");
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
                var carro = _db.Vehiculos.Find(IdCarro);
                var cliente = _db.Clientes.Find(IdCliente);
                if (carro == null || cliente == null || CantidadDePagos == 0)
                {
                    _logger.LogError("Error en la solicitud");
                    return NotFound();
                }
                var registro = new RegistroCredito(cliente, carro);
                registro.CalcularCouta(CantidadDePagos);
                _db.RegistrosCredito.Add(registro);
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
