using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Repository.ResponseRepository
{
    public class ResponseRepository : AbstractSqlRepository<Response, long>, IResponseRepository
    {
        public ResponseRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        public Response GetResponseByObjectionId(long id, string hospitalName)
        {
            var response = context.Responses.Where(r => r.ObjectionIdFromHospitalDatabase.Equals(id) && r.HospitalName.Equals(hospitalName)).FirstOrDefault();
            return response;
        }

        protected override long GetId(Response entity)
        {
            return entity.Id;
        }
    }
}
