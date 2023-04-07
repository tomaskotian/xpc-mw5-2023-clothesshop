﻿using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ClothesShop.Common.Enums;

namespace ClothesShop.DAL.Entities
{
    public class ManufacturerEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public Origin Origin { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public List<object> Commodities { get; set; } = new List<object>();
    }
}