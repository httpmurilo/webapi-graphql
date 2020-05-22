using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiGraph.Entities
{
    public class Category : Entity
    {
       
        public int Code {get; set;}
        public string Name {get; set;}
        
        public DateTime DateRegister {get; set;}

        [JsonIgnore]
        public IEnumerable<Product> Products {get; set;}

        public override string ToString() => $"{Code} - {Name}";
        
    }
}