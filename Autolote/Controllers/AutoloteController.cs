using Autolote.Data;
using Autolote.Models;
using Autolote.Models.DTO;
using Autolote.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoloteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AutoloteController> _logger;
        private readonly IClienteRepository _ClienteRepos;


        public AutoloteController(ILogger<AutoloteController> logger, IClienteRepository repos, IMapper mapper)
        {
            _ClienteRepos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Obteniendoclientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllClientes()
        {
            _logger.LogInformation("Solicitando lista de clientes");
            var clientes = await _ClienteRepos.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(clientes));
        }
        
        [HttpGet("{cedula}", Name ="GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDTO>> GetCliente(string cedula)
        {
            var cliente = await _ClienteRepos.Get(s => s.CedulaId == cedula);
            return Ok(_mapper.Map<Cliente>(cliente));
        }

        //[HttpGet]
        //[Route("RegistroCredito")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> GetRegistrosCredito()
        //{
        //    _logger.LogInformation("Solicitando lista de registro creditos");
        //    return Ok(await _db.RegistrosVentas.ToListAsync());
        //}

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

        public async Task<ActionResult<ClienteDTO>> PostCliente([FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se pudo crear el cliente");
                return BadRequest();
            }

            if (await _ClienteRepos.Get(s => s.CedulaId == cliente.CedulaId) != null)
            {
                ModelState.AddModelError("Nombre Existe", "!La cedula ingresada ya existe en nuesta base de datos¡");
                return BadRequest(ModelState);
            }
            if (cliente == null)
                return BadRequest(cliente);

            Cliente modelo = _mapper.Map<Cliente>(cliente);
            await _ClienteRepos.Create(modelo);

            _logger.LogInformation("Cliente creado con exito");
            return CreatedAtRoute("GetCliente", new { cedula = modelo.CedulaId }, modelo);
        }

        //[HttpPost]
        //[Route("AgregarCarro")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> PostCarro([FromBody] VehiculoDTO vehiculo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("No se puedo crear el vehiculo");
        //    }
        //    if (await _ClienteRepos.get) != null)
        //    {
        //        _logger.LogError("El chasis ya existia, no se creo el vehiculo");
        //        ModelState.AddModelError("Chasis Existe", "El Chasis ingresado ya existe en nuestra base de datos!");
        //        return BadRequest(ModelState);
        //    }
        //    if (vehiculo == null)
        //    {
        //        _logger.LogError("No ingreso los datos requeridos");
        //        ModelState.AddModelError("Datos no validos", "Los datos que se ingresaron como parametros no son validos");
        //        return BadRequest(ModelState);
        //    }
        //    _db.Vehiculos.Add(new Vehiculo()
        //    {
        //        Marca = vehiculo.Marca,
        //        Precio = vehiculo.Precio,
        //        Estado = vehiculo.Estado,
        //        AñoFab = vehiculo.AñoFab,
        //        Color = vehiculo.Color,
        //        Descripcion = vehiculo.Descripcion
        //    });
        //    _db.SaveChanges();
        //    _logger.LogInformation("Carro creado con exito");
        //    return Ok();
        //}

        //[HttpPost("InsertarRegistro/{IdCarro}/{IdCliente}/{CantidadDePagos}/")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult PostRegistro(int IdCarro, int IdCliente, int CantidadDePagos)
        //{
        //    try
        //    {
        //        var carro = _db.Vehiculos.Find(IdCarro);
        //        var cliente = _db.Clientes.Find(IdCliente);
        //        if (carro == null || cliente == null || CantidadDePagos == 0)
        //        {
        //            _logger.LogError("Error en la solicitud");
        //            return NotFound();
        //        }
        //        var registro = new RegistroVenta(cliente, carro);
        //        registro.CalcularCouta(CantidadDePagos);
        //        _db.RegistrosVentas.Add(registro);
        //        _db.SaveChanges();
        //        _logger.LogInformation("Registro creado con exito");
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("No se pudo completar el POST, mensaje de error: " + ex.Message);
        //        return BadRequest();
        //    }
        //}
    }
}
