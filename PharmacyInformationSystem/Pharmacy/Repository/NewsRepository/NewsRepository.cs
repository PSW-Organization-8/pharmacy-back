using System;
using System.Collections.Generic;
using System.Text;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Repository.NewsRepository
{
    public class NewsRepository : AbstractSqlRepository<News, long>, INewsRepository
    {
        public NewsRepository(MyDbContext context) : base(context)
        {
        }

        protected override long GetId(News entity)
        {
            return entity.Id;
        }
    }
}
