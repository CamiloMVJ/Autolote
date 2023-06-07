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
            return Ok(await _db.RegistrosVentas.ToListAsync());
        }

        //[HttpGet]
        //[Route("RegistroContado")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> GetRegistrosContado()
        //{
        //    _logger.LogInformation("Solicitando lista de registro contado");
        //    return Ok(await _db.RegistrosContado.ToListAsync());
        //}

        [HttpPost]
        [Route("AgregarCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> PostCliente([FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se pudo crear el cliente");
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

        [HttpPost]
        [Route("AgregarCarro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PostCarro([FromBody] VehiculoDTO vehiculo)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se puedo crear el vehiculo");
            }
            if(await _db.Vehiculos.FindAsync(vehiculo.Chasis) != null)
            {
                _logger.LogError("El chasis ya existia, no se creo el vehiculo");
                ModelState.AddModelError("Chasis Existe", "El Chasis ingresado ya existe en nuestra base de datos!");
                return BadRequest(ModelState);
            }
            if(vehiculo == null)
            {
                _logger.LogError("No ingreso los datos requeridos");
                ModelState.AddModelError("Datos no validos", "Los datos que se ingresaron como parametros no son validos");
                return BadRequest(ModelState);
            }
            _db.Vehiculos.Add(new Vehiculo()
            {
                Marca = vehiculo.Marca,
                Precio = vehiculo.Precio,
                Estado = vehiculo.Estado,
                AñoFab = vehiculo.AñoFab,
                Color = vehiculo.Color,
                Descripcion = vehiculo.Descripcion
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
                var carro = _db.Vehiculos.Find(IdCarro);
                var cliente = _db.Clientes.Find(IdCliente);
                if (carro == null || cliente == null || CantidadDePagos == 0)
                {
                    _logger.LogError("Error en la solicitud");
                    return NotFound();
                }
                var registro = new RegistroVenta(cliente, carro);
                registro.CalcularCouta(CantidadDePagos);
                _db.RegistrosVentas.Add(registro);
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
