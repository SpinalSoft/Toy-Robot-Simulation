using Microsoft.AspNetCore.Mvc;
using ToyRobot.BusinessLogic.BusinessWrapper;
using ToyRobot.Main.Models;

namespace ToyRobot.Main.Controllers
{
    public class PositionController : Controller
    {
        private readonly IBusinessWrapper _business;
        public PositionController(IBusinessWrapper business)
        {
            _business = business;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormFile postedFile)
        {
            var supportedTypes = new[] { "txt" };
            var fileExt = System.IO.Path.GetExtension(postedFile.FileName).Substring(1);

            if (!supportedTypes.Contains(fileExt))
            {
                ViewBag.Message = "File Extension Is InValid - Only Upload txt File";
                return View();
            }

            var commandList = ReadFile(postedFile);
            var position = _business.commandBL.Start(commandList);

            ViewBag.Message = position;

            return View();
        }

        public List<string> ReadFile(IFormFile postedFile)
        {
            List<string> command = new List<string>();
            string message = string.Empty;
            try
            {
                if (postedFile == null || postedFile.Length == 0)
                {
                    message = ("No file selected for upload...");
                }

                using (var reader = new StreamReader(postedFile.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        command.Add(reader.ReadLine());
                    }
                }

                return command;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
