using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.IngredientMedicationRepository
{
    public class IngredientsInMediactionRepository : AbstractSqlRepository<IngredientInMediaction, long>, IIngredientsInMediactionRepository
    {
        public IngredientsInMediactionRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(IngredientInMediaction entity)
        {
            return entity.Id;
        }
    }
}
