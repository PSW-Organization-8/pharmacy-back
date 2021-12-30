using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Repository.TenderingRepository
{
    public interface ITenderingRepository:IGenericRepository<Tender, long>
    {
        List<Tender> GetAllWithMedications();

    }
}
