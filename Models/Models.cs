
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace VetApi.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Pet_ID")]
        [JsonProperty("Pet_ID")]
        public Int32 Pet_ID { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Age")]
        [JsonProperty("Age")]
        public DateTime Age { get; set; }

        [BsonElement("Genus")]
        [JsonProperty("Genus")]
        public string Genus { get; set; }

        [BsonElement("Breed")]
        [JsonProperty("Breed")]
        public string Breed { get; set; }

        [BsonElement("Gender")]
        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [BsonElement("Neutered")]
        [JsonProperty("Neutered")]
        public Boolean Neutered { get; set; }

        [BsonElement("Owner_ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("Owner_ID")]
        public string Owner_ID { get; set; }

        [JsonProperty("Owner_Name")]
        public string Owner_Name { get; set; }
    }

    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Member_ID")]
        [JsonProperty("Member_ID")]
        public Int32 Member_ID { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Member_Start")]
        [JsonProperty("Member_Start")]
        public DateTime Member_Start { get; set; }

        [BsonElement("Cell_Phone")]
        [JsonProperty("Cell_Phone")]
        public string Cell_Phone { get; set; }

        [BsonElement("Home_Phone")]
        [JsonProperty("Home_Phone")]
        public string Home_Phone { get; set; }

        [BsonElement("Email")]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [BsonElement("Address")]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [BsonElement("Username")]
        [JsonIgnore]
        public string Username { get; set; }

        [BsonElement("Password")]
        [JsonIgnore]
        public string Password { get; set; }

        [BsonElement("Salt")]
        [JsonIgnore]
        public string Salt { get; set; }
    }

    public class Vet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("ID")]
        [JsonProperty("ID")]
        public Int32 ID { get; set; }

        [BsonElement("Specialty")]
        [JsonProperty("Specialty")]
        public string Specialty { get; set; }

        [BsonElement("Cell_Phone")]
        [JsonProperty("Cell_Phone")]
        public string Cell_Phone { get; set; }

        [BsonElement("On_Call")]
        [JsonProperty("On_Call")]
        public string On_Call { get; set; }

        [BsonElement("Time")]
        [JsonProperty("Time")]
        public string Time { get; set; }

        [BsonElement("Days_Off")]
        [JsonProperty("Days_Off")]
        public string Days_Off { get; set; }

        [BsonElement("Username")]
        [JsonIgnore]
        public string Username { get; set; }

        [BsonElement("Password")]
        [JsonIgnore]
        public string Password { get; set; }

        [BsonElement("Salt")]
        [JsonIgnore]
        public string Salt { get; set; }
    }

    public class Med

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        [JsonProperty("Category")]
        public string Category { get; set; }

        [BsonElement("Pills")]
        [JsonProperty("Pills")]
        public Int32 Pills { get; set; }

        [BsonElement("Volume")]
        [JsonProperty("Volume")]
        public Int32 Volume { get; set; }

        [BsonElement("Concentration")]
        [JsonProperty("Concentration")]
        public Int32 Concentration { get; set; }

        [BsonElement("Price")]
        [JsonProperty("Price")]
        public Double Price { get; set; }
    }

    public class Vacc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Genus")]
        [JsonProperty("Genus")]
        public string Genus { get; set; }

        [BsonElement("Price")]
        [JsonProperty("Price")]
        public Double Price { get; set; }

        [BsonElement("Dosis_Less_16_Weeks")]
        [JsonProperty("Dosis_Less_16_Weeks")]
        public string Dosis_Less_16_Weeks { get; set; }

        [BsonElement("Dosis_More_16_Weeks")]
        [JsonProperty("Dosis_More_16_Weeks")]
        public string Dosis_More_16_Weeks { get; set; }

        [BsonElement("Frequency")]
        [JsonProperty("Frequency")]
        public string Frequency { get; set; }
    }

    public class TypeItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Number")]
        [JsonProperty("Number")]
        public Int32 Number { get; set; }

        [BsonElement("Type")]
        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("OwnerID")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("OwnerID")]
        public string OwnerID { get; set; }

        [BsonElement("Date")]
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Amount")]
        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [BsonElement("Type")]
        [JsonProperty("Type")]
        public Int32 Type { get; set; }

        [BsonElement("IsPaid")]
        [JsonProperty("IsPaid")]
        public bool IsPaid { get; set; }
    }

    public class Consult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PetID")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("PetID")]
        public string PetID { get; set; }

        [BsonElement("VetID")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("VetID")]
        public string VetID { get; set; }

        [BsonElement("Date")]
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Message")]
        [JsonProperty("Message")]
        public string Message { get; set; }

        //
        [JsonProperty("Meds")]
        [BsonIgnore]
        public List<Dictionary<string, object>> Meds { get; set; }

        [BsonElement("Meds")]
        [JsonIgnore]
        public BsonArray MedsBson { get; set; }
        //
        //
        [JsonProperty("Vaccs")]
        [BsonIgnore]
        public List<Dictionary<string, object>> Vaccs { get; set; }

        [BsonElement("Vaccs")]
        [JsonIgnore]
        public BsonArray VaccsBson { get; set; }
        //

        [JsonProperty("PetName")]
        public string PetName { get; set; }

        [JsonProperty("VetName")]
        public string VetName { get; set; }
    }
}
