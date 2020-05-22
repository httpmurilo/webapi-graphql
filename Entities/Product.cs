using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGraph.Entities
{
    public class Product : Entity
    {
        [Required]
        [StringLength(200)]
        public string Name {get; set;}
        
        [Column(TypeName="decimal(18,2)")]
        public decimal Price {get; set;}
        public Category Category {get; set;}
        public string Description {get; set;}
        public DateTime DateRegister {get; set;}

        [JsonIgnore]
        public Guid CategoryId {get; set;}
    }
}