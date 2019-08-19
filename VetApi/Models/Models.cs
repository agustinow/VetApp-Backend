﻿
using System;
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
        public string Pet_ID { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Age")]
        [JsonProperty("Age")]
        public string Age { get; set; }

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
        public string Neutered { get; set; }
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
        public string Member_Start { get; set; }

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
        public Array Days_Off { get; set; }
    }

    public class Med
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [BsonElement("Quantity")]
        [JsonProperty("Quantity")]
        public Int32 Quantity { get; set; }

        [BsonElement("Concentration")]
        [JsonProperty("Concentration")]
        public string Concentration { get; set; }

        [BsonElement("Category")]
        [JsonProperty("Category")]
        public string Category { get; set; }

        [BsonElement("Price")]
        [JsonProperty("Price")]
        public Int32 Price { get; set; }
    }

}