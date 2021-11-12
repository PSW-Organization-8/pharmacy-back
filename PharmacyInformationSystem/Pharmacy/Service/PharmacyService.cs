using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public Pharmacy Get(long id)
        {
            return pharmacyRepository.Get(id);
        }

        public List<Pharmacy> GetAll()
        {
            return pharmacyRepository.GetAll();
        }
    }
}
