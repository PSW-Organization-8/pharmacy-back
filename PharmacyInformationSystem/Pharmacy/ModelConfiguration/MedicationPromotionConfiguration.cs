using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyClassLib.Model.Commercials;

namespace PharmacyClassLib.ModelConfiguration
{
    class MedicationPromotionConfiguration : IEntityTypeConfiguration<MedicationPromotion>
    {
        public void Configure(EntityTypeBuilder<MedicationPromotion> builder)
        {
            builder.ToTable("MedicationPromotion");
            builder.HasKey(medicationPomotion => medicationPomotion.Id);
            builder.OwnsOne(medicationPomotion => medicationPomotion.PromotionPeriod);
        }
    }

}
