using System;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Shipping;
using Nop.Core.Plugins;
using Nop.Plugin.Pickup.Plantilla.Data;
using Nop.Plugin.Pickup.Plantilla.Domain;
using Nop.Plugin.Pickup.Plantilla.Services;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Shipping.Pickup;
using Nop.Services.Shipping.Tracking;

namespace Nop.Plugin.Pickup.Plantilla
{
    public class PlantillaProvider : BasePlugin, IPickupPointProvider
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ILocalizationService _localizationService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IStoreContext _storeContext;
        private readonly IStorePlantillaService _storeTemplateService;
        private readonly StorePlantillaObjectContext _objectContext;

        #endregion

        #region Ctor

        public PlantillaProvider(IAddressService addressService,
            ICountryService countryService,
            ILocalizationService localizationService,
            IStateProvinceService stateProvinceService,
            IStoreContext storeContext,
            IStorePlantillaService storePickupPointService,
            StorePlantillaObjectContext objectContext)
        {
            this._addressService = addressService;
            this._countryService = countryService;
            this._localizationService = localizationService;
            this._stateProvinceService = stateProvinceService;
            this._storeContext = storeContext;
            this._storeTemplateService = storePickupPointService;
            this._objectContext = objectContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a shipment tracker
        /// </summary>
        public IShipmentTracker ShipmentTracker
        {
            get { return null; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get pickup points for the address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Represents a response of getting pickup points</returns>
        public GetPickupPointsResponse GetPickupPoints(Address address)
        {
            var result = new GetPickupPointsResponse();

            foreach (var point in _storeTemplateService.GetAllStorePickupPoints(_storeContext.CurrentStore.Id))
            {
                var pointAddress = _addressService.GetAddressById(point.AddressId);
                if (pointAddress != null)
                    result.PickupPoints.Add(new PickupPoint
                    {
                        Id = point.Id.ToString(),
                        Name = point.Name,
                        Description = point.Description,
                        Address = pointAddress.Address1,
                        City = pointAddress.City,
                        StateAbbreviation = pointAddress.StateProvince != null ? pointAddress.StateProvince.Abbreviation : string.Empty,
                        CountryCode = pointAddress.Country != null ? pointAddress.Country.TwoLetterIsoCode : string.Empty,
                        ZipPostalCode = pointAddress.ZipPostalCode,
                        OpeningHours = point.OpeningHours,
                        PickupFee = point.PickupFee,
                        ProviderSystemName = PluginDescriptor.SystemName
                    });
            }

            if (result.PickupPoints.Count == 0)
                result.AddError(_localizationService.GetResource("Plugins.Pickup.PickupInStore.NoPickupPoints"));

            return result;
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "Plantilla";
            routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.Pickup.Plantilla.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //database objects
            _objectContext.Install();

            //sample pickup point
            var country = _countryService.GetCountryByThreeLetterIsoCode("USA");
            var state = _stateProvinceService.GetStateProvinceByAbbreviation("NY");
            var address = new Address
            {
                Address1 = "21 West 52nd Street",
                City = "New York",
                CountryId = country != null ? (int?)country.Id : null,
                StateProvinceId = state != null ? (int?)state.Id : null,
                ZipPostalCode = "10021",
                CreatedOnUtc = DateTime.UtcNow
            };
            _addressService.InsertAddress(address);

            var pickupPoint = new StorePlantillaRecord
            {
                Name = "New York store",
                AddressId = address.Id,
                OpeningHours = "10.00 - 19.00",
                PickupFee = 1.99m
            };
            _storeTemplateService.InsertStorePlantillaRecord(pickupPoint);

            //locales
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.AddNew", "Add a new pickup point");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Description", "Description");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Description.Hint", "Specify a description of the pickup point.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Name", "Name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Name.Hint", "Specify a name of the pickup point.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.OpeningHours", "Opening hours");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.OpeningHours.Hint", "Specify an openning hours of the pickup point (Monday - Friday: 09:00 - 19:00 for example).");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.PickupFee", "Pickup fee");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.PickupFee.Hint", "Specify a fee for the shipping to the pickup point.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Store", "Store");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Store.Hint", "A store name for which this pickup point will be available.");
            this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.Plantilla.NoPickupPoints", "No pickup points are available");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //database objects
            _objectContext.Uninstall();

            //locales
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.AddNew");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Description");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Description.Hint");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Name");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Name.Hint");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.OpeningHours");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.OpeningHours.Hint");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.PickupFee");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.PickupFee.Hint");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Store");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.Fields.Store.Hint");
            this.DeletePluginLocaleResource("Plugins.Pickup.Plantilla.NoPickupPoints");

            base.Uninstall();
        }

        #endregion
    }
}
