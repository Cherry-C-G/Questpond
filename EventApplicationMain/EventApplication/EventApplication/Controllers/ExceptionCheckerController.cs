using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class ExceptionCheckerController : Controller
    {
        //
        // GET: /ExceptionChecker/

        public ActionResult Index()
        {

            DirectoryInfo dirinfo = new DirectoryInfo(Server.MapPath("~/Errorlog/"));

            string validExtensions = "*.txt";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();

            foreach (string extension in extFilter)
            {
                files.AddRange(dirinfo.GetFiles(extension));
                try
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        StreamReader fb;
                        string filename = files[i].ToString();
                        fb = System.IO.File.OpenText(dirinfo + filename);
                        string input = null;
                        while ((input = fb.ReadLine()) != null)
                        {
                            Response.Write(input + "</br>");
                        }
                        fb.Close();
                    }

                }
                catch (Exception)
                {
                    throw;

                }
            }
            return View();
        }

    }
}
