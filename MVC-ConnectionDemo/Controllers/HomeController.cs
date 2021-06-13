using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient; 


namespace MVC_ConnectionDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DBManager dm = new DBManager(); 



        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            string tf1 = frm[0];
            string tf2 = frm[1];
            string q = "insert into tbl_testdb values('" + tf1 + "','" + tf2 + "')";
            bool res = dm.InsertUpdateDelete(q);
            if (res == true)
            {
                ViewBag.confirm = "Record Inserted Successfully";
            }
            else
            {
                ViewBag.confirm = "Database Error or Query Error";
            }

            
            return View();

        }

        public ActionResult DisplayRecords()
        {
            string q = "select * from tbl_testdb";
            DataTable dt = new DataTable();
            dt = dm.ReadBulkData(q);
            string tbl = "<table class='table table-striped'>";
            int i;
            tbl += "<tr>";
            tbl += "<th>TestField 1 </th><th>TestField 2</th>";
            tbl += "</tr>";

            for (i = 0; i < dt.Rows.Count; i++)
            {
                tbl += "<tr>";
                tbl += "<td>" + dt.Rows[i][0] + "</td>";
                tbl += "<td>" + dt.Rows[i][1] + "</td>";
                tbl += "</tr>";


            }
            tbl += "</table>";
            ViewBag.table = tbl;


            return View();
        }
       


    }
}
