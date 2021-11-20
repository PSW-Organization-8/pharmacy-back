using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Repository.RegistratedHospitalRepository
{
    public class RegisteredHospitalRepository : AbstractSqlRepository<RegisteredHospital, string>, IRegisteredHospitalRepository
    {
        public RegisteredHospitalRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override string GetId(RegisteredHospital entity)
        {
            return entity.Name;
        }

        public bool ExistsByApiKey(string apiKey)
        {
            var query = context.RegistratedHospitals.Where(s => s.ApiKey.Equals(apiKey)).FirstOrDefault();
            if (query == null)
            {
                return false;
            }

            return true;
        }

        public RegisteredHospital GetByApiKey(string apyKey)
        {
            return context.RegistratedHospitals.Where(h => h.ApiKey.Equals(apyKey)).FirstOrDefault();
        }

        public RegisteredHospital GetByName(string name)
        {
            return context.RegistratedHospitals.Where(h => h.Name.Equals(name)).FirstOrDefault();
        }
    }
}
