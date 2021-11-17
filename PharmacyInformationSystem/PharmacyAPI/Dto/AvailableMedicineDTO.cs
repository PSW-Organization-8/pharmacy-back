using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class AvailableMedicineDTO
    {
        public string Name { get; set; }
        public long Id { get; set; }

        public AvailableMedicineDTO() { }

        public AvailableMedicineDTO(string name, long id) {
            this.Name = name;
            this.Id = id;
        }
    }
}
