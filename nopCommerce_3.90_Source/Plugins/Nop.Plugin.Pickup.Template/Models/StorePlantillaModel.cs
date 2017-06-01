using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Pickup.Plantilla.Models
{
    public class StorePlantillaModel : BaseNopEntityModel
    {
        public StorePlantillaModel()
        {
            this.Address = new AddressModel();
            AvailableStores = new List<SelectListItem>();
        }

        public AddressModel Address { get; set; }

        [NopResourceDisplayName("Plugins.Pickup.Plantilla.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Plugins.Pickup.Plantilla.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Plugins.Pickup.Plantilla.Fields.PickupFee")]
        public decimal PickupFee { get; set; }

        [NopResourceDisplayName("Plugins.Pickup.Plantilla.Fields.OpeningHours")]
        public string OpeningHours { get; set; }

        public List<SelectListItem> AvailableStores { get; set; }
        [NopResourceDisplayName("Plugins.Pickup.Plantilla.Fields.Store")]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Address.Fields.Country")]
        public int? CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.StateProvince")]
        public int? StateProvinceId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.Address1")]
        [AllowHtml]
        public string Address1 { get; set; }

        [NopResourceDisplayName("Admin.Address.Fields.ZipPostalCode")]
        [AllowHtml]
        public string ZipPostalCode { get; set; }
    }
}