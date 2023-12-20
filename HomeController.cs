using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Connection conn = new Connection();
        public ActionResult Index()
        {
            string que = "insert into Employe(id,name,gender,age) values('1','Amit','Male','20')";
            conn.Executequerise(que);
            Employee emp = new Employee();
            string queq = "select * from Employe where id=1";
          var asdf=  conn.DataReader(queq);
            if (asdf != null && asdf.Rows.Count > 0)
            {
                emp.id = asdf.Rows[0][0].ToString();
                emp. name = asdf.Rows[0][1].ToString();
                emp.gender = asdf.Rows[0][2].ToString();
                emp.age =int.Parse( asdf.Rows[0][3].ToString());
               
            }
            return View();
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