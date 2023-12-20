using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Amit_priyam_crud.Models
{
    public class DBmanager
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        protected string MycommandText { get; set; }

        public DBmanager()
        {
            con = new SqlConnection("Data Source=AMITLAPTOP\\AMITYADAV; initial catalog=AP1; Integrated Security=true");
        }
        protected bool ExecuteInsertUpdateOrDelete()
        {
            cmd = new SqlCommand(MycommandText, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            return n > 0 ? true : false;
        }
        protected DataTable ExceuteSelect()
        {

            SqlDataAdapter da = new SqlDataAdapter(MycommandText, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        var picpath = "";
                    if (PicFile != null)
                    {
                       
                        if (PicFile != null && PicFile.ContentLength > 0)
                        {
                            Guid imgid = Guid.NewGuid();
        var path = Path.Combine(Server.MapPath("~/Uploads/ClientProfilePic"));
        string pathString = System.IO.Path.Combine(path.ToString());
        var fileName1 = Path.GetFileName(PicFile.FileName);
        string extension = Path.GetExtension(PicFile.FileName);
        bool isExists = System.IO.Directory.Exists(pathString);
                            if (!isExists) System.IO.Directory.CreateDirectory(pathString);
                            var uploadpath = string.Format("{0}\\{1}", pathString, imgid.ToString().Substring(0, 8) + extension);
        PicFile.SaveAs(uploadpath);
                            var filepath = "~/Uploads/ClientProfilePic/" + imgid.ToString().Substring(0, 8) + extension;
        picpath= filepath;
                        }
}
    }
}