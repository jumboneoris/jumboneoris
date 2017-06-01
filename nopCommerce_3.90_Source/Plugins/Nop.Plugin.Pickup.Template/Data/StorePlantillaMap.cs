using Nop.Data.Mapping;
using Nop.Plugin.Pickup.Plantilla.Domain;

namespace Nop.Plugin.Pickup.Plantilla.Data
{
    public partial class StorePlantillaMap : NopEntityTypeConfiguration<StorePlantillaRecord>
    {
        public StorePlantillaMap()
        {
            this.ToTable("StorePlantilla");
            this.HasKey(point => point.Id);
            this.Property(point => point.PickupFee).HasPrecision(18, 4);
        }
    }
}