using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IResponseService
    {
        Response Add(Response response);

        List<Response> GetAll();

        Response GetResponseByObjectionId(long id, string hospitalName);
    }
}
