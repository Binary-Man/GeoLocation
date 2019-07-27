using GeoLocation.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace GeoLocation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogHelper.GetLogger();

        private LogHelper _logWriter = new LogHelper();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Search model)
        {
            if (ModelState.IsValid)
            {
                //var logfile = new FileInfo("log4net.xml");
                //log4net.Config.XmlConfigurator.Configure(logfile);

                if (model.Location?.Length > 1)
                {
                    _log.Info($"Address entered: {model.Address} Google found location: {model.Location}");
                    _logWriter.LogWrite($"Address entered: {model.Address} Google found location: {model.Location}");
                }
                else
                {
                    _log.Error($"Location NOT FOUND, Address entered: {model.Address} ");
                    _logWriter.LogWrite($"Location NOT FOUND, Address entered: {model.Address} ");
                    ModelState.AddModelError("NotFound", "The address entered could not be located using Google Map Services, Please try again");
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}