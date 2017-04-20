using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class PeopleManageBll : CommonBll
    {
        PeopleManageDao dao = new PeopleManageDao();
        public DataTable GetAll(string name, int pageIndex, int pageSize)
        {
            DataSet _ds = dao.GetAllPeoples(name, pageIndex, pageSize);
            return _ds.Tables[0];
        }

        public int GetTotalCount(string name)
        {
            return dao.GetTotalCount(name);
        }

        public int CreatePeople(string cardNum, string name, string team, string remark)
        {
            DataTable dt = GetItemById(cardNum);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dao.CreatePeople(cardNum, name, team, remark);
            } 
            else
            {
                return dao.UpdatePeople(cardNum, name, team, remark);
            }
          
        }

        public DataTable GetItemById(string id)
        {
            return dao.GetItemById(id);
        }

        public int DeletePeople(string cardNum)
        {
            return dao.DeletePeople(cardNum);
        }
    }
}
