using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VetApi.Models;
using VetApi.Services;

namespace VetApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class VetController : ControllerBase
    {
        private readonly NetworkService _networkservice;

        public VetController(NetworkService networkservice)
        {
            _networkservice = networkservice;
        }

        [HttpGet("vets")]
        public ActionResult<List<Vet>> GetVet() =>
            _networkservice.GetAllVet();

        [HttpGet("vets/{id:length(24)}", Name = "GetVet")]
        public ActionResult<Vet> GetVet(string id)
        {
            var vet = _networkservice.GetVet(id);

            if (vet == null)
            {
                return NotFound();
            }

            return vet;
        }

        [HttpPost("vets")]
        [Authorize(Policy = "RequireAdmin")]
        public ActionResult<Vet> CreateVet(Vet vet)
        {
            _networkservice.CreateVet(vet);

            return CreatedAtRoute("GetVet", new { id = vet.Id.ToString() }, vet);
        }

        [HttpPut("vets/{id:length(24)}")]
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult UpdateVet(string id, Vet vetIn)
        {
            var vet = _networkservice.GetVet(id);

            if (vet == null)
            {
                return NotFound();
            }

            _networkservice.UpdateVet(id, vetIn);

            return NoContent();
        }

        [HttpDelete("vets/{id:length(24)}")]
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult RemoveVet(string id)
        {
            var vet = _networkservice.GetVet(id);

            if (vet == null)
            {
                return NotFound();
            }

            _networkservice.RemoveVet(vet.Id);

            return NoContent();
        }

        //Pet

        [HttpGet("pets")]
        public ActionResult<List<Pet>> GetPet() =>
            _networkservice.GetAllPet();

        [HttpGet("petsof/{id:length(24)}", Name = "GetPetsOfOID")]
        public ActionResult<List<Pet>> GetPetsOfOID(string id) =>
            _networkservice.GetAllPetsOf(id);

        [HttpGet("petsof/{id}", Name = "GetPetsOf")]
        public ActionResult<List<Pet>> GetPetsOf(int id)
        {
            var user = _networkservice.GetOwner(id);
            if (user == null) return NotFound();
            var pets = _networkservice.GetAllPetsOf(user.Id);
            if (pets == null) return NoContent();
            return pets;
        }

        [HttpGet("pets/{id:length(24)}", Name = "GetPet")]
        public ActionResult<Pet> GetPet(string id)
        {
            var pet = _networkservice.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost("pets")]
        public ActionResult<Pet> CreatePet(Pet pet)
        {
            _networkservice.CreatePet(pet);

            return CreatedAtRoute("GetVet", new { id = pet.Id.ToString() }, pet);
        }

        [HttpPut("pets/{id:length(24)}")]
        public IActionResult UpdatePet(string id, Pet petIn)
        {
            var pet = _networkservice.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            _networkservice.UpdatePet(id, petIn);

            return NoContent();
        }

        [HttpDelete("pets/{id:length(24)}")]
        public IActionResult DeletePet(string id)
        {
            var pet = _networkservice.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            _networkservice.RemovePet(pet.Id);

            return NoContent();
        }

        //Owner

        [HttpGet("owners")]
        public ActionResult<List<Owner>> GetOwner() =>
            _networkservice.GetAllOwner();

        [HttpGet("owners/{id:length(24)}", Name = "GetOwner")]
        public ActionResult<Owner> GetOwner(string id)
        {
            var owner = _networkservice.GetOwner(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        [HttpPost("owners")]
        public ActionResult<Owner> CreateOwner(Owner owner)
        {
            _networkservice.CreateOwner(owner);

            return CreatedAtRoute("GetOwner", new { id = owner.Id.ToString() }, owner);
        }

        [HttpPut("owners/{id:length(24)}")]
        public IActionResult UpdateOwner(string id, Owner ownerIn)
        {
            var owner = _networkservice.GetOwner(id);

            if (owner == null)
            {
                return NotFound();
            }

            _networkservice.UpdateOwner(id, ownerIn);

            return NoContent();
        }

        [HttpDelete("owners/{id:length(24)}")]
        public IActionResult DeleteOwner(string id)
        {
            var owner = _networkservice.GetOwner(id);

            if (owner == null)
            {
                return NotFound();
            }

            _networkservice.RemoveOwner(owner.Id);

            return NoContent();
        }


        //Med

        [HttpGet("med")]
        public ActionResult<List<Med>> GetMed() =>
            _networkservice.GetAllMed();

        [HttpGet("med/{id:length(24)}", Name = "GetMed")]
        public ActionResult<Med> GetMed(string id)
        {
            var med = _networkservice.GetMed(id);

            if (med == null)
            {
                return NotFound();
            }

            return med;
        }

        [HttpPost("med")]
        public ActionResult<Med> CreateMed(Med med)
        {
            _networkservice.CreateMed(med);

            return CreatedAtRoute("GetMed", new { id = med.Id.ToString() }, med);
        }

        [HttpPut("med/{id:length(24)}")]
        public IActionResult UpdateMed(string id, Med medIn)
        {
            var med = _networkservice.GetMed(id);

            if (med == null)
            {
                return NotFound();
            }

            _networkservice.UpdateMed(id, medIn);

            return NoContent();
        }

        [HttpDelete("med/{id:length(24)}")]
        public IActionResult DeleteMed(string id)
        {
            var med = _networkservice.GetMed(id);

            if (med == null)
            {
                return NotFound();
            }

            _networkservice.RemoveMed(med.Id);

            return NoContent();
        }

        //Vacc

        [HttpGet("vacc")]
        public ActionResult<List<Vacc>> GetVacc() =>
            _networkservice.GetAllVacc();

        [HttpGet("vacc/{id:length(24)}", Name = "GetVacc")]
        public ActionResult<Vacc> GetVacc(string id)
        {
            var vacc = _networkservice.GetVacc(id);

            if (vacc == null)
            {
                return NotFound();
            }

            return vacc;
        }

        [HttpPost("vacc")]
        public ActionResult<Vacc> CreateVacc(Vacc vacc)
        {
            _networkservice.CreateVacc(vacc);

            return CreatedAtRoute("GetVacc", new { id = vacc.Id.ToString() }, vacc);
        }

        [HttpPut("vacc/{id:length(24)}")]
        public IActionResult UpdateVacc(string id, Vacc vaccIn)
        {
            var vacc = _networkservice.GetVacc(id);

            if (vacc == null)
            {
                return NotFound();
            }

            _networkservice.UpdateVacc(id, vaccIn);

            return NoContent();
        }

        [HttpDelete("vacc/{id:length(24)}")]
        public IActionResult DeleteVacc(string id)
        {
            var vacc = _networkservice.GetVacc(id);

            if (vacc == null)
            {
                return NotFound();
            }

            _networkservice.RemoveVacc(vacc.Id);

            return NoContent();
        }

        //CONSULTS
        [HttpGet("consults")]
        public ActionResult<List<Consult>> GetConsults() =>
            _networkservice.GetAllConsults();

        [HttpGet("consults/{id:length(24)}", Name = "GetConsult")]
        public ActionResult<Consult> GetConsult(string id)
        {
            var consult = _networkservice.GetConsult(id);

            if (consult == null)
            {
                return NotFound();
            }

            return consult;
        }

        //PAYMENTS
        [HttpGet("payments")]
        public ActionResult<List<Payment>> GetPayments() =>
            _networkservice.GetAllPayments();

        [HttpGet("payments/{id:length(24)}", Name = "GetPayment")]
        public ActionResult<Payment> GetPayment(string id)
        {
            var payment = _networkservice.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpGet("paymentsof/{id:length(24)}", Name = "GetPaymentsOfOID")]
        public ActionResult<List<Payment>> GetPaymentsOfOID(string id)
        {
            var payments = _networkservice.GetAllPaymentsOf(id);

            if (payments == null)
            {
                return NoContent();
            }

            return payments;
        }

        [HttpGet("paymentsof/{id}", Name = "GetPaymentsOf")]
        public ActionResult<List<Payment>> GetPaymentsOf(int id)
        {
            var user = _networkservice.GetOwner(id);
            if (user == null) return NotFound();

            var payments = _networkservice.GetAllPaymentsOf(user.Id);
            if (payments == null) return NoContent();
            return payments;
        }

        //TYPES
        [HttpGet("types")]
        public ActionResult<List<TypeItem>> GetTypes() =>
            _networkservice.GetAllTypes();

        [HttpGet("types/{id:length(24)}", Name = "GetType")]
        public ActionResult<TypeItem> GetType(string id)
        {
            var type = _networkservice.GetType(id);

            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

    }
}