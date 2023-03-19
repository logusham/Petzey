using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petzey.Pet.DTO;
using Petzey.Pet.Model;
using Petzey.Pet.Repository.DataAccessLayer;
using Petzey.Pet.Repository.Interface;
using Petzey.Pet.Service.Service.Implementation;
using Petzey.Pet.Service.Service.Interface;
using NLog;

namespace Petzey.Pet.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PetController : ControllerBase
    {
        private IPetService service;
        public PetDbContext petDb;
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        public PetController(IPetService petService,PetDbContext petDb)
        {
            this.petDb = petDb;
            this.service = petService;
        }
        //public PetController()
        //{

        //}
        [HttpGet]
        public ActionResult<List<PetProfile>> GetAllPet()
        {
            try
            {
                List<ViewAllPetDTO> petProfiles = service.GetAllPet();
                if (petProfiles!= null)
                {
                    return Ok(petProfiles);
                }
                return NotFound("PetProfile Not Found");
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        //Add PetProfile
        [HttpPost]
        [Route("{PetOwnerId:guid}")]
        public ActionResult<PetProfile> AddPetProfile([FromRoute] Guid PetOwnerId, [FromBody] AddPetDTO addPet)
        {
            try
            {
                PetProfile petProfile =  service.AddPet(PetOwnerId, addPet);
                if(petProfile != null)
                {
                    return Ok(petProfile);
                }
                return NotFound("PetProfile Not Found");

            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //Get single PetOwner
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPetOwner")]
        public ActionResult<PetOwner> GetCard([FromRoute] Guid id)
        {
            try
            {
                PetOwnerDTO petOwner = service.GetPetOwner(id);
                if (petOwner != null)
                {
                    return Ok(petOwner);
                }
                return NotFound("PetProfile Not Found");
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            

        }
        // Edit A PetOwner
        [HttpPut]
        [Route("{id:guid}")]

        public ActionResult<PetOwner> EditPetOwner([FromRoute] Guid id, [FromBody] PetOwner petOwner)
        {
            try
            {
                PetOwner pet = service.EditPetOwner(id, petOwner);
                if (pet != null)
                {
                    return Ok(pet);
                }
                return NotFound("PetProfile Not Found");
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
        //[HttpPost]
        //public IActionResult Add(PetOwner petOwner)
        //{
        //    petOwner.Id = Guid.NewGuid();
        //    petDb.PetOwner.Add(petOwner);
        //    petDb.SaveChanges();
        //    return Ok(petOwner);
        //}
    }
}
