using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace app.Pages
{
    public class StatModel : PageModel
    {
        private readonly ILogger<StatModel> _logger;

        public StatModel(ILogger<StatModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "counter.txt");
            int currentCounter;
            using (StreamReader sr = new StreamReader(path))
            {
                currentCounter = Convert.ToInt32(sr.ReadToEnd());
                ViewData["Counter"] = currentCounter;
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                currentCounter = currentCounter + 1;
                sw.WriteLine(currentCounter);
            }
        }
    }
}
