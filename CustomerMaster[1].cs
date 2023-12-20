using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_ADO_CRUD.Models
{
    public class CustomerMaster:ConnectionManager
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string PicName { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }
        public string Added_On { get; set; }
        internal bool AddNewCustomer()
        {
            MyCommandText = "Insert into CustomerMaster values('" + Name + "','" +
                Gender + "','" + City + "','" + EmailId + "','" + MobileNo + "','" + PicName
                + "','" + Password + "','" + Added_On + "')";
            return ExecuteMyNonQuery();
        }
        internal bool DeleteCustomer(int CustomerId)
        {
            MyCommandText = "Delete from CustomerMaster where CustomerId='" + CustomerId + "'";
            return ExecuteMyNonQuery();
        }
        internal bool UpdateCustomerRecord(int cid)
        {
            if(PicName!=null)
               MyCommandText = "Update CustomerMaster set Name='" + Name +
                "',Gender='" + Gender + "',City='" + City +
                "',EmailId='" + EmailId + "',MobileNo='" + MobileNo
                + "',PicName='" + PicName + "',Pass='" + Password + "' where CustomerId='" + cid + "'";
           else
                MyCommandText = "Update CustomerMaster set Name='" + Name +
                "',Gender='" + Gender + "',City='" + City +
                "',EmailId='" + EmailId + "',MobileNo='" + MobileNo
                + "',Pass='" + Password + "' where CustomerId='" + cid + "'";

            return ExecuteMyNonQuery();
        }
        internal CustomerMaster GetRecordOfCustomer(int cid)
        {
            MyCommandText = "Select *from CustomerMaster where CustomerId='" + cid + "'";
            DataTable dt = ExecuteMyQuery();
            CustomerMaster cm = new CustomerMaster();
            if(dt!=null && dt.Rows.Count>0)
            {
                cm.CustomerId=int.Parse( dt.Rows[0][0].ToString());
                cm.Name = dt.Rows[0][1].ToString();
                cm.Gender = dt.Rows[0][2].ToString();
                cm.City = dt.Rows[0][3].ToString();
                cm.EmailId = dt.Rows[0][4].ToString();
                cm.MobileNo = dt.Rows[0][5].ToString();
                cm.PicName = dt.Rows[0][6].ToString();
                cm.Password = dt.Rows[0][7].ToString();
                cm.Added_On = dt.Rows[0][8].ToString();
            }
            return cm;
        }
        internal List<CustomerMaster> GetRecordOfAllCustomers()
        {
            MyCommandText = "Select *from CustomerMaster order by CustomerId desc";
            DataTable dt = ExecuteMyQuery();
            List<CustomerMaster> LstCm = new List<CustomerMaster>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    CustomerMaster cm = new CustomerMaster();
                    cm.CustomerId = int.Parse(dr[0].ToString());
                    cm.Name = dr[1].ToString();
                    cm.Gender = dr[2].ToString();
                    cm.City = dr[3].ToString();
                    cm.EmailId = dr[4].ToString();
                    cm.MobileNo = dr[5].ToString();
                    cm.PicName = dr[6].ToString();
                    cm.Password = dr[7].ToString();
                    cm.Added_On = dr[8].ToString();
                    LstCm.Add(cm);
                }
            }
            return LstCm;
        }
    }
}