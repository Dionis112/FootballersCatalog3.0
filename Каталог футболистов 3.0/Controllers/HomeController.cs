using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Каталог_футболистов_3._0.Models;
using Каталог_футболистов_3._0.Models.Context;

namespace Каталог_футболистов_3._0.Controllers
{
    public class HomeController : Controller
    {
        FootballersContext FC;
        public HomeController(FootballersContext context)
        {
            FC = context;
        }

        public IActionResult Index()
        {
            ViewBag.FootBallers = FC.Footballers.ToList();
            return View();
        }

        public IActionResult Item(int? Id)
        {
            Footballers footBallers = FC.Footballers.Where(f => f.Id == Id).FirstOrDefault();
            ViewBag.Teams = JsonConvert.SerializeObject(FC.Footballers.Select(s => s.NameTeam).ToList());

            if (Id != null)
            {
                ViewBag.TypePage = "Edit";

            }
            else if (Id == null)
            {
                ViewBag.TypePage = "New";
            }

            return View(footBallers);
        }

        [HttpPost]
        public string SaveItem(string footBaller)
        {
            string result = "";
            try
            {
                Footballers footballers = JsonConvert.DeserializeObject<Footballers>(footBaller);
                if (footballers.Id == 0)
                {
                    FC.Add(footballers);
                    FC.SaveChanges();
                    result = JsonConvert.SerializeObject(new { status = "OK" });
                }
                else
                {
                    FC.Entry(footballers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    FC.SaveChanges();
                    result = JsonConvert.SerializeObject(new { status = "OK" });
                }
            }
            catch (Exception ex)
            {
                result = JsonConvert.SerializeObject(new { status = "Error", Error = ex.ToString() });
            }
            return result;
        }
    }
}
