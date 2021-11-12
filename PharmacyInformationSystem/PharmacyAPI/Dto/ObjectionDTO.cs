using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class ObjectionDto
    {
        public long Id { get; set; }
        public string PharmacyName { get; set; }
        public string TextObjection { get; set; }

        public ObjectionDto() { }

        public ObjectionDto(string text, string name)
        {

            TextObjection = text;
            PharmacyName = name;

        }
    }
}
