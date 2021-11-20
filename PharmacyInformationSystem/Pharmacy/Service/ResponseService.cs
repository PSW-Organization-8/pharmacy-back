using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class ResponseService: IResponseService
    {
        private readonly IResponseRepository responseRepository;

        public ResponseService(IResponseRepository responseRepository)
        {
            this.responseRepository = responseRepository;
        }

        public Response Add(Response response)
        {
            return responseRepository.Create(response);
        }

        public List<Response> GetAll()
        {
            return responseRepository.GetAll();
        }

        public Response GetResponseByObjectionId(long id, string hospitalName)
        {
            Response response = responseRepository.GetResponseByObjectionId(id, hospitalName);
            if (response == null) {
                response = new Response();
            }
            return response;
        }
    }
}
