using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Repository.IngredientMedicationRepository
{
    public class IngredientsInMedicationRepository : AbstractSqlRepository<IngredientInMedication, long>, IIngredientsInMedicationRepository
    {
        public IngredientsInMedicationRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(IngredientInMedication entity)
        {
            return entity.Id;
        }
    }
}
