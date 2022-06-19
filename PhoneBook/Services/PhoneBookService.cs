using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Data;
using System.Data;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly DataAccessLayer dataAccessLayer;
        public PhoneBookService(DataAccessLayer dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }
        public List<PhoneBookModel> GetAll()
        {
            DataTable dt = dataAccessLayer.ExecuteSelect("Mproc_SelectPhone", null, true);
            List<PhoneBookModel> list = new List<PhoneBookModel>();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    PhoneBookModel obj = new PhoneBookModel();
                    obj.Index = i + 1;
                    obj.ID = dt.Rows[i]["ID"].ToString() == null? 0: int.Parse(dt.Rows[i]["ID"].ToString());
                    obj.Name = dt.Rows[i]["Name"].ToString() == null?"": dt.Rows[i]["Name"].ToString();
                    obj.FirstNumber = dt.Rows[i]["FirstNumber"].ToString() == null ? "" : dt.Rows[i]["FirstNumber"].ToString();
                    obj.SecondNumber = dt.Rows[i]["SecondNumber"].ToString() == null ? "" : dt.Rows[i]["SecondNumber"].ToString();
                    obj.DeleteStatus = dt.Rows[i]["Delete_Status"].ToString() == null?0: int.Parse(dt.Rows[i]["Delete_Status"].ToString());
                    list.Add(obj);
                }
            }
            return list;
        }

        public PhoneBookModel GetDataByID(int ID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@ID"] = ID;
            DataTable dt = dataAccessLayer.ExecuteSelect("Mproc_GetPhoneByID", parameter, true);
            PhoneBookModel obj = new PhoneBookModel();
            if (dt.Rows.Count > 0)
            {
                obj.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                obj.Name = dt.Rows[0]["Name"].ToString();
                obj.FirstNumber = dt.Rows[0]["FirstNumber"].ToString();
                obj.SecondNumber = dt.Rows[0]["SecondNumber"].ToString();
                obj.DeleteStatus = int.Parse(dt.Rows[0]["Delete_Status"].ToString());
            }
            else
            {
                obj.ID = 0;
                obj.Name = "";
                obj.FirstNumber ="";
                obj.SecondNumber = "";
                obj.DeleteStatus = 0;

            }
            return obj;
        }

        public int Insert(PhoneBookModel t)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Name"] = t.Name;
            parameter["@FirstNumber"] = t.FirstNumber;
            parameter["@SecondNumber"] = t.SecondNumber;

            int row = dataAccessLayer.ExecuteDML("MProc_AddPhone", parameter, true);
            return row;
        }

        public int Update(PhoneBookModel t)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@ID"] = t.ID;
            parameter["@Name"] = t.Name;
            parameter["@FirstNumber"] = t.FirstNumber;
            parameter["@SecondNumber"] = t.SecondNumber;

            int row = dataAccessLayer.ExecuteDML("MProc_UpdatePhoneBook", parameter, true);
            return row;
        }
        public int Delete(int ID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@ID"] = ID;
           
            int row = dataAccessLayer.ExecuteDML("Mproc_DeletePhone", parameter, true);
            return row;
        }
        
        public List<PhoneBookModel> SearchNumber(string search)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Name"] = search;

            DataTable dt = dataAccessLayer.ExecuteSelect("Mproc_SearchPhoneByName", parameter, true);
            List<PhoneBookModel> list = new List<PhoneBookModel>();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    PhoneBookModel obj = new PhoneBookModel();
                    obj.Index = i + 1;
                    obj.ID = dt.Rows[i]["ID"].ToString() == null ? 0 : int.Parse(dt.Rows[i]["ID"].ToString());
                    obj.Name = dt.Rows[i]["Name"].ToString() == null ? "" : dt.Rows[i]["Name"].ToString();
                    obj.FirstNumber = dt.Rows[i]["FirstNumber"].ToString() == null ? "" : dt.Rows[i]["FirstNumber"].ToString();
                    obj.SecondNumber = dt.Rows[i]["SecondNumber"].ToString() == null ? "" : dt.Rows[i]["SecondNumber"].ToString();
                    obj.DeleteStatus = dt.Rows[i]["Delete_Status"].ToString() == null ? 0 : int.Parse(dt.Rows[i]["Delete_Status"].ToString());
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
