using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public interface IPharmacyService
    {
        List<Pharmacy> GetAll();

        Pharmacy Get(long id);
    }
}
