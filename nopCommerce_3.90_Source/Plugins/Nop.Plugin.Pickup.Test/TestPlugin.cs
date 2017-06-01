using Nop.Core.Plugins;
using Nop.Services.Shipping.Pickup;
using System;
using Nop.Core.Domain.Common;
using Nop.Services.Shipping.Tracking;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Core;
using Nop.Plugin.Pickup.Test.Data;
using System.Web.Routing;

namespace Nop.Plugin.Pickup.Test
{
    public class TestPlugin : BasePlugin, IPickupPointProvider
    {
        #region Fields

        public IAddressService _addressService;
        public ICountryService _countryService;
        public ILocalizationService _localizationService;
        public IStateProvinceService _stateProvinceService;
        public IStoreContext _storeContext;
        //private readonly IStorePickupPointService _storePickupPointService;
        public TestObjectContext _objectContext;

        #endregion

        #region Ctor

        public TestPlugin(IAddressService addressService,
            ICountryService countryService,
            ILocalizationService localizationService,
            IStateProvinceService stateProvinceService,
            IStoreContext storeContext,
            //IStorePickupPointService storePickupPointService,
            TestObjectContext objectContext)
        {
            this._addressService = addressService;
            this._countryService = countryService;
            this._localizationService = localizationService;
            this._stateProvinceService = stateProvinceService;
            this._storeContext = storeContext;
            //this._storePickupPointService = storePickupPointService;
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
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "Test";
            routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.Pickup.Test.Controllers" }, { "area", null } };
        }

        public GetPickupPointsResponse GetPickupPoints(Address address)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //database objects
            _objectContext.Install();

            // Local Resources guardados en DB
            //this.AddOrUpdatePluginLocaleResource("Plugins.Pickup.PickupInStore.AddNew", "Add a new pickup point");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //database objects
            _objectContext.Unistall();

            // Local Resources guardados en DB
            //this.DeletePluginLocaleResource("Plugins.Pickup.PickupInStore.AddNew");

            base.Uninstall();
        }

        #endregion
    }
}