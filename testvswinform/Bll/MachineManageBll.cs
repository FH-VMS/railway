using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class MachineManageBll
    {
        MachineManageDao dao = new MachineManageDao();
        public DataTable GetAll(int pageIndex, int pageSize)
        {
            DataSet _ds = dao.GetAllMachines( pageIndex, pageSize);
            return _ds.Tables[0];
        }

        public int GetTotalCount()
        {
            return dao.GetTotalCount();
        }

        public int CreateMachine(string id, string machine_type, string describe,string machine_name)
        {
            DataTable dt = GetItemById(id);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dao.CreateMachine(id, machine_type, describe, machine_name);
            }
            else
            {
                return dao.UpdateMachine(id, machine_type, describe, machine_name);
            }

        }

        public DataTable GetItemById(string id)
        {
            return dao.GetItemById(id);
        }

        public int DeleteMachine(string id)
        {
            return dao.DeleteMachine(id);
        }
    }
}
