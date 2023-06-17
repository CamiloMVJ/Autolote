using Autolote.Models;
using Autolote.Models.DTO;
using Autolote.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Autolote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroVentaController> _logger;
        private readonly IRegistroRepository _RegistroRepos;

        public RegistroVentaController(ILogger<RegistroVentaController> logger, IRegistroRepository repos, IMapper mapper)
        {
            _RegistroRepos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "ListaRegistros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RegistroVentaDTO>>> GetAllRegistros()
        {
            _logger.LogInformation("Solicitando lista de registros");
            var registros = await _RegistroRepos.GetAll();
            return Ok(_mapper.Map<IEnumerable<RegistroVentaDTO>>(registros));
        }

        [HttpGet("{id:int}", Name = "GetRegistro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegistroVentaDTO>> GetRegistro(int Id)
        {
            var registro = await _RegistroRepos.Get(s => s.RegistroId == Id);   
            return Ok(_mapper.Map<RegistroVenta>(registro));
        }

        [HttpPost(Name = "AgregarRegistro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RegistroVentaDTO>> PostRegistro([FromBody] RegistroVentaCreateDTO registro)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("No se pudo crear el registro");
                return BadRequest();
            }
            //if (await _RegistroRepos.Get(s => s.RegistroId == registro.RegistroId) != null)
            //{
            //    ModelState.AddModelError("Id Existe", "!El registro ya existe en nuesta base de datos¡");
            //    return BadRequest(ModelState);
            //}
            if (registro == null)
                return BadRequest(registro);

            RegistroVenta modelo = _mapper.Map<RegistroVenta>(registro);
            await _RegistroRepos.Create(modelo);

            _logger.LogInformation("Registro creado con exito");
            return CreatedAtRoute("GetRegistro", new { Id = modelo.RegistroId }, modelo);
        }

        [HttpDelete(Name = "BorarRegistro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteRegistro(int id)
        {
            if (id == 0)
                return BadRequest();
            var registro = await _RegistroRepos.Get(s => s.RegistroId == id);
            if (registro == null)
            {
                ModelState.AddModelError("Registro no encontrado", "El id ingresado no corresponde para ningun registro");
                return NotFound(ModelState);
            }

            await _RegistroRepos.Remove(registro);
            return NoContent();
        }

        [HttpPut(Name = "ActualizarRegistro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRegistro(int id, [FromBody] RegistroVentaUpdateDTO registro)
        {
            if (id == 0)
                return BadRequest(id);
            if (registro == null)
                return BadRequest(registro);
            if (registro.RegistroId != id)
                return BadRequest();

            var modelo = _mapper.Map<RegistroVenta>(registro);
            await _RegistroRepos.UpdateRegistro(modelo);
            return NoContent();
        }
    }
}
