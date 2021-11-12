using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.ObjectionRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class ObjectionService   // Todo: Write interface for this class
    {
        private readonly IObjectionRepository objectionRepository;

        public ObjectionService(IObjectionRepository objectionRepository)
        {
            this.objectionRepository = objectionRepository;
        }

        public Objection Add(Objection objection)
        {
            return objectionRepository.Create(objection);
        }

        public List<Objection> GetAll()
        {
            return objectionRepository.GetAll();
        }
    }
}
