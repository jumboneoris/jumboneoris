using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Plugin.Widgets.HelloWorld.Domain;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.HelloWorld.Controllers
{
    public class HelloWorldController : BasePluginController
    {
        private IRepository<Domain.HelloWorldRecord> _helloWorldRepo;
        private readonly IPictureService _pictureService;
        private readonly ICacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public HelloWorldController(IRepository<Domain.HelloWorldRecord> helloWorldRepo, IPictureService pictureService, ICacheManager cacheManager, ISettingService settingService, ILocalizationService localizationService)
        {
            _helloWorldRepo = helloWorldRepo;
            _pictureService = pictureService;
            _cacheManager = cacheManager;
            _settingService = settingService;
            _localizationService = localizationService;
        }

        public ActionResult Configure()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var nivoSliderSettings = _settingService.LoadSetting<Domain.HelloWorldSettings>(0);
            Domain.HelloWorldRecord _model = new HelloWorldRecord();
            _model.Message = nivoSliderSettings.Message;
            _model.UrlImg = nivoSliderSettings.UrlImg;
            return View("~/Plugins/Widgets.HelloWorld/Views/Configure.cshtml", _model);
        }

        [HttpPost]
        public ActionResult Configure(HelloWorldRecord model)
        {
            HelloWorldRecord _record = new HelloWorldRecord();
            //_record.Id = id;
            //_record.Message = message;
            //_record.UrlImg = urlImg;
            _record.Id = model.Id;
            _record.Message = model.Message;
            _record.UrlImg = model.UrlImg;
            _helloWorldRepo.Insert(_record);
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
            //return Json(new { Result = true, Message = message }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateUpdateHelloWorld(int Id = 0)
        {
            HelloWorldRecord _helloWorld = new HelloWorldRecord();
            if (Id > 0)
            {
                _helloWorld = _helloWorldRepo.GetById(Id);
            }

            return View("~/Plugins/Nop.Plugin.Widgets.HelloWorld/Views/CreateUpdateHelloWorld.cshtml", _helloWorld);

        }

        [HttpPost]
        public ActionResult CreateUpdateHelloWorld(HelloWorldRecord record)
        {
            if (ModelState.IsValid)
            {
                HelloWorldRecord _hwRecord = _helloWorldRepo.GetById(record.Id);
                if (_hwRecord == null)
                {
                    _helloWorldRepo.Insert(record);
                    SuccessNotification("Se ha grabado con exito");
                    return RedirectToRoute(new
                    {
                        Action = "CreateUpdateHelloWorld",
                        Controller = "HelloWorld",
                        ID = record.Id
                    });
                }
                else
                {
                    _hwRecord.Message = record.Message;
                    _hwRecord.UrlImg = record.UrlImg;
                    _helloWorldRepo.Update(_hwRecord);
                    _cacheManager.Clear();
                    SuccessNotification("Cambios realizados con exito");
                    return View("~/Plugins/Nop.Plugin.Widgets.HelloWorld/Views/CreateUpdateHelloWorld.cshtml", _hwRecord);
                }
            }
            else
            {
                return View("~/Plugins/Nop.Plugin.Widgets.HelloWorld/Views/CreateUpdateHelloWorld.cshtml");
            }
        }

        //[AdminAuthorize]
        //[ChildActionOnly]
        //public ActionResult Configure()
        //{
        //    return View("~/Plugins/Nop.Plugin.Widgets.HelloWorld/Views/Configure.cshtml", new HelloWorldRecord);
        //}

        //[HttpPost]
        //[AdminAuthorize]
        //[ChildActionOnly]
        //public ActionResult Configure(HelloWorldRecord model)
        //{
        //    return Configure();
        //}

    }
}