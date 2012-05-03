using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcSignalrGritterDemo.Processing;

namespace MvcSignalrGritterDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		[HttpPost]
		public ActionResult UploadFile()
		{
			var fileProcessor = new FileProcessor();
			ThreadPool.QueueUserWorkItem(fileProcessor.ProcessFileCallback);

			return RedirectToAction("About");
		}
	}
}
