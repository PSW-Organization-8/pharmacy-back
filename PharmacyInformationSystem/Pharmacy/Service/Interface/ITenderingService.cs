using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service.Interface
{
    public interface ITenderingService
    {
        Tender Create(Tender tender);
        bool Remove(Tender tender);
        Tender Update(Tender tender);
        Tender Get(long id);
        List<Tender> GetAll();

        List<Tender> GetAllWithMedication();

    }
}
