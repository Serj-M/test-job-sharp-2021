using Antiplagiat150221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;

namespace Antiplagiat150221.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public class Lang
        {
            public string header { get; set; }
            public string text { get; set; }
        }

        public partial class Langs
        {
            [JsonProperty("en")]
            public Fields En { get; set; }

            [JsonProperty("ru")]
            public Fields Ru { get; set; }
        }

        public partial class Fields
        {
            [JsonProperty("header")]
            public string Header { get; set; }

            [JsonProperty("choice")]
            public string Choice { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("portfolio")]
            public string Portfolio { get; set; }
        }

        // метод для смены языка в UI
        public JsonResult ChangeLanguage(string name)
        {
            using (StreamReader r = new StreamReader("langs.json"))
            {
                string json = r.ReadToEnd();
                Langs items = JsonConvert.DeserializeObject<Langs>(json);
                Console.WriteLine($"items: {items.En.Text}");
                if (name == "en") {
                    return Json(items.En);
                } else {
                    return Json(items.Ru);
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
