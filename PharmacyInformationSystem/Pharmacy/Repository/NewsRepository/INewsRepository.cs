using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Repository.NewsRepository
{
    public interface INewsRepository : IGenericRepository<News, long>
    {
    }
}
