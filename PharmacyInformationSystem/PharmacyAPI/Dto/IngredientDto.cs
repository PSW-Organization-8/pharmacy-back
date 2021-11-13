using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class IngredientDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public List<long> Ids { get; set; }

        IngredientDto() { }

        public IngredientDto(string name, long id, List<long> ids)
        {
            Name = name;
            Id = id;
            Ids = ids;
        }
    }
}
