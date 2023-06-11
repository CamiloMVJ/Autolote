using Autolote.Models;
using Autolote.Models.DTO;
using Autolote.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AutoloteController> _logger;
        private readonly IVehiculoRepository _VehiculoRepos;

        public VehiculoController(ILogger<AutoloteController> logger, IVehiculoRepository repos, IMapper mapper)
        {
            _VehiculoRepos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "GetVehiculo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehiculoDTO>> GetStudent(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer Estudiante con Id {id}");
                return BadRequest();
            }
            var vehiculo = await _VehiculoRepos.Get(s => s.VehiculoId == id);

            if (vehiculo == null)
            {
                _logger.LogError($"Error al traer Estudiante con Id {id}");
                return NotFound();
            }

            return Ok(_mapper.Map<Vehiculo>(vehiculo));
        }

        [HttpPost]
        [Route("AgregarCarro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehiculoDTO>> PostCarro([FromBody] VehiculoCreateDTO vehiculo)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se puedo crear el vehiculo");
            }
            if (vehiculo == null)
            {
                _logger.LogError("No ingreso los datos requeridos");
                ModelState.AddModelError("Datos no validos", "Los datos que se ingresaron como parametros no son validos");
                return BadRequest(ModelState);
            }

            Vehiculo modelo = _mapper.Map<Vehiculo>(vehiculo);
            await _VehiculoRepos.Create(modelo);
            _logger.LogInformation("Se agrego el vehiculo con exito!");
            return CreatedAtRoute("GetVehiculo", new { id = modelo.VehiculoId }, modelo);
        }
    }
}
