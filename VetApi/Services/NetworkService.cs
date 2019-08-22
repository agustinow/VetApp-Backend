using System;
using System.Collections.Generic;
using MongoDB.Driver;
using VetApi.Models;

namespace VetApi.Services
{
    public class NetworkService : IUserManagementService
    {
        private readonly IMongoCollection<Pet> _pets;
        private readonly IMongoCollection<Owner> _owners;
        private readonly IMongoCollection<Vet> _vets;
        private readonly IMongoCollection<Med> _med;
        private readonly IMongoCollection<Vacc> _vacc;
        private readonly IMongoCollection<TypeItem> _types;
        private readonly IMongoCollection<Payment> _payments;
        private readonly IMongoCollection<Consult> _consults;

        public NetworkService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pets = database.GetCollection<Pet>(settings.PetCollectionName);
            _owners = database.GetCollection<Owner>(settings.OwnersCollectionName);
            _vets = database.GetCollection<Vet>(settings.VetCollectionName);
            _med = database.GetCollection<Med>(settings.MedCollectionName);
            _vacc = database.GetCollection<Vacc>(settings.VaccCollectionName);
            _types = database.GetCollection<TypeItem>(settings.TypeCollectionName);
            _payments = database.GetCollection<Payment>(settings.PaymentCollectionName);
            _consults = database.GetCollection<Consult>(settings.ConsultCollectionName);
        }
        
        public List<Pet> GetAllPet() =>
            _pets.Find(pets => true).ToList();

        public List<Pet> GetAllPetsOf(string id) =>
            _pets.Find(pet => pet.Owner_ID == id).ToList();

        public Pet GetPet(string id) =>
            _pets.Find<Pet>(pet => pet.Id == id).FirstOrDefault();

        public Pet GetPet(int id) =>
            _pets.Find<Pet>(pet => pet.Pet_ID == id).FirstOrDefault();

        public List<Owner> GetAllOwner() =>
            _owners.Find(owners => true).ToList();

        public Owner GetOwner(string id) =>
            _owners.Find<Owner>(owners => owners.Id == id).FirstOrDefault();

        public Owner GetOwner(Int32 id) =>
            _owners.Find<Owner>(owners => owners.Member_ID == id).FirstOrDefault();

        public List<Vet> GetAllVet() =>
            _vets.Find(vets => true).ToList();

        public Vet GetVet(string id) =>
            _vets.Find<Vet>(vet => vet.Id == id).FirstOrDefault();

        public Vet GetVet(int id) =>
            _vets.Find<Vet>(vet => vet.ID == id).FirstOrDefault();

        public List<Med> GetAllMed() =>
          _med.Find(med => true).ToList();

        public Med GetMed(string id) =>
            _med.Find<Med>(med => med.Id == id).FirstOrDefault();

        public List<Vacc> GetAllVacc() =>
          _vacc.Find(vacc => true).ToList();

        public Vacc GetVacc(string id) =>
            _vacc.Find<Vacc>(vacc => vacc.Id == id).FirstOrDefault();

        public List<Consult> GetAllConsults()
        {
            var consults = _consults.Find(consult => true).ToList();
            foreach (Consult consult in consults)
            {
                var pet = this.GetPet(consult.PetID);
                var vet = this.GetVet(consult.VetID);
                if (pet != null) consult.PetName = pet.Name;
                else consult.PetName = "";
                if (vet != null) consult.VetName = vet.Name;
                else consult.VetName = "";
            }
            return consults;
        }

        public List<Consult> GetAllConsultsOf(string vetID)
        {
            var consults = _consults.Find(consult => consult.VetID == vetID).ToList();
            foreach (Consult consult in consults)
            {
                var pet = this.GetPet(consult.PetID);
                var vet = this.GetVet(consult.VetID);
                if (pet != null) consult.PetName = pet.Name;
                else consult.PetName = "";
                if (vet != null) consult.VetName = vet.Name;
                else consult.VetName = "";
            }
            return consults;
        }

        public List<Consult> GetAllConsultsFor(string petID)
        {
            var consults = _consults.Find(consult => consult.PetID == petID).ToList();
            foreach (Consult consult in consults)
            {
                var pet = this.GetPet(consult.PetID);
                var vet = this.GetVet(consult.VetID);
                if (pet != null) consult.PetName = pet.Name;
                else consult.PetName = "";
                if (vet != null) consult.VetName = vet.Name;
                else consult.VetName = "";
            }
            return consults;
        }


        public Consult GetConsult(string id) =>
            _consults.Find<Consult>(consult => consult.Id == id).FirstOrDefault();

        public List<TypeItem> GetAllTypes() =>
            _types.Find(type => true).ToList();

        public TypeItem GetType(string id) =>
            _types.Find(type => type.Id == id).FirstOrDefault();

        public List<Payment> GetAllPayments() =>
            _payments.Find(payment => true).ToList();

        public List<Payment> GetAllPaymentsOf(string id) =>
            _payments.Find(payment => payment.OwnerID == id).ToList();

        public Payment GetPayment(string id) =>
            _payments.Find(payment => payment.Id == id).FirstOrDefault();

        public Vet CreateVet(Vet vet)
        {
            _vets.InsertOne(vet);
            return vet;
        }

        public void UpdateVet(string id, Vet vetIn) =>
            _vets.ReplaceOne(vet => vet.Id == id, vetIn);

        public void RemoveVet(string id) =>
            _vets.DeleteOne(vet => vet.Id == id);



        public Pet CreatePet(Pet pets)
        {
            _pets.InsertOne(pets);
            return pets;
        }

        public void UpdatePet(string id, Pet petIn) =>
            _pets.ReplaceOne(pet => pet.Id == id, petIn);

        public void RemovePet(string id) =>
            _pets.DeleteOne(pet => pet.Id == id);

        public Owner CreateOwner(Owner owner)
        {
            _owners.InsertOne(owner);
            return owner;
        }

        public void UpdateOwner(string id, Owner ownerIn) =>
            _owners.ReplaceOne(owner => owner.Id == id, ownerIn);

        public void RemoveOwner(string id) =>
            _owners.DeleteOne(owner => owner.Id == id);




        public Med CreateMed(Med med)
        {
            _med.InsertOne(med);
            return med;
        }

        public void UpdateMed(string id, Med medIn) =>
            _med.ReplaceOne(med => med.Id == id, medIn);

        public void RemoveMed(string id) =>
            _med.DeleteOne(med => med.Id == id);


        public Vacc CreateVacc(Vacc vacc)
        {
            _vacc.InsertOne(vacc);
            return vacc;
        }

        public void UpdateVacc(string id, Vacc vaccIn) =>
            _vacc.ReplaceOne(vacc => vacc.Id == id, vaccIn);

        public void RemoveVacc(string id) =>
            _vacc.DeleteOne(vacc => vacc.Id == id);


        //CHECK USER
        public string IsValidUser(string username, string password, out Boolean passwordRight)
        {
            var returnVal = "null";
            passwordRight = false;
            var vet = _vets.Find<Vet>(person => person.Username == username).FirstOrDefault();
            if (vet != null)
            {
                returnVal = "vet";
                passwordRight |= vet.Password == password;
            }
            var owner = _owners.Find<Owner>(person => person.Username == username).FirstOrDefault();
            if (owner != null)
            {
                returnVal = "owner";
                passwordRight |= owner.Password == password;
            }
            return returnVal;
        }
    }

    public interface IUserManagementService
    {
        string IsValidUser(string username, string password, out Boolean passwordRight);
    }
}
