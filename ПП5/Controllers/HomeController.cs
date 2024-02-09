using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using ПП5.Models;
using System.Linq;
using System.Text;

namespace ПП5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private int _counter = 0;
        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult TaskSecond()
        {
            return View();
        }


        public IActionResult TaskThird()
        {
            return View();
        }



            [HttpPost]
        
        public IActionResult TaskFirst(string Number)
        {
            if (Convert.ToInt32(Number) % 7 == 0)
            {
                int num = Convert.ToInt32(Number) / 7;
                ViewBag.Result = Number + ":7=" + num;
            }
            else
            {
                ViewBag.Result = $"Число {Convert.ToInt32(Number)} не делится на 7 без остатка";
            }

            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string stroka)
        {
            

            StringBuilder str = new StringBuilder(stroka);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'с')
                {
                    str = str.Remove(i, 1);
                    str = str.Append('_');
                }
            }
            ViewBag.Result2 = str;
            return View();
        }

        [HttpPost]
        public IActionResult TaskThird(string Number)
        {
            string strr = "";
            int stroka1 = 0;
            int stroka2 = 0;
            Random rand = new Random();

            int n = Convert.ToInt32(Number);
            int[] arr1 = new int[2*n];

            for (int i = 0; i < 2 * n; i++)

            {
                arr1[i] = rand.Next(10);
                strr += arr1[i];
            }
            


            for (int i = 0; i < 2 * n; i++)

            {
                if (i%2 != 0)
                {
                    stroka1 = stroka1+ arr1[i] * arr1[i];
                    stroka2 = stroka2 + arr1[i] * arr1[i] * arr1[i];
                }
            }
            ViewBag.Result1 = "Сгенерированный массив:" + strr;
            ViewBag.Result2 = "Сумма квадратов элементов с четными индексами:" + stroka1;
            ViewBag.Result3 = "Сумма кубов элементов с четными индексами:" + stroka2;

            return View();
        }







    }
}
