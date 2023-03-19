using AutoMapper;
using Petzey.Pet.DTO;
using Petzey.Pet.Model;
using Petzey.Pet.Repository.DataAccessLayer;
using Petzey.Pet.Repository.Implementation;
using Petzey.Pet.Repository.Interface;
using Petzey.Pet.Service.Service.Interface;

namespace Petzey.Pet.Service.Service.Implementation
{
    public class PetService : IPetService
    {
        public IPetRepository repo;
        private readonly IMapper _mapper;
        public PetDbContext db;
        public PetService(PetDbContext petDb,IMapper mapper)
        {
            repo = new PetRepository(petDb);
            _mapper = mapper;
            db = petDb;
        }

        public PetProfile AddPet(Guid Id,AddPetDTO addPetDTO)
        {
            PetProfile petProfile = _mapper.Map<AddPetDTO, PetProfile>(addPetDTO);
            petProfile.PetOwnerId = Id;
            petProfile.Id = Guid.NewGuid();
            bool result = repo.AddPet(petProfile);
            if (result)
            {
                return petProfile;
            }
            return null;
        }

        public PetOwner EditPetOwner(Guid Id, PetOwner petOwner)
        {
            return (repo.EditPetOwner(Id,petOwner));
        }

        public List<ViewAllPetDTO> GetAllPet()
        {
            List<PetProfile> pets = repo.GetAllPet();
             List<ViewAllPetDTO> viewAllPets = _mapper.Map<List<PetProfile>, List<ViewAllPetDTO>>(pets);
            return (viewAllPets);
        }

        public PetOwnerDTO GetPetOwner(Guid Id)
        {
            PetOwner petOwner = repo.GetPetOwner(Id);
            var petOwnerDTO = _mapper.Map<PetOwner, PetOwnerDTO>(repo.GetPetOwner(Id));
            return (petOwnerDTO);
        }
    }
}