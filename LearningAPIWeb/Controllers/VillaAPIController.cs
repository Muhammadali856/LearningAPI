using LearningAPIWeb.Data;
using LearningAPIWeb.Models;
using LearningAPIWeb.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LearningAPIWeb.Controllers
{
    [Route("api/DachaAPI")]
    [ApiController]
    public class DachaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DachaDTO>> GetDachas()
        {
            return Ok(DachaStore.dachaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        //[ProducesResponseType(200, Type = typeof(VillaDTO)]
        public ActionResult<DachaDTO> GetDachaById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var dacha = DachaStore.dachaList.FirstOrDefault(u => u.Id == id);
            if (dacha == null)
            {
                return NotFound();
            }
            return Ok(dacha);
        }



        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DachaDTO> GetDachaByName(string name)
        {
            var dacha = DachaStore.dachaList.FirstOrDefault(u => u.Name.ToLower() == name.ToLower());
            if (dacha == null)
            {
                return NotFound();
            }

            return Ok(dacha);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DachaDTO> CreateDacha([FromBody] DachaDTO dachaDTO)
        {
            if (dachaDTO == null)
            {
                return BadRequest(dachaDTO);
            }
            if (dachaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            dachaDTO.Id = DachaStore.dachaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            DachaStore.dachaList.Add(dachaDTO);

            return Ok(dachaDTO);

        }
    
    }
}
