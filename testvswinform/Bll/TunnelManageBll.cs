using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class TunnelManageBll
    {
        TunnelManageDao dao = new TunnelManageDao();
        public DataTable GetAll(string machine_num, int pageIndex, int pageSize)
        {
            DataSet _ds = dao.GetAllTunnels(machine_num, pageIndex, pageSize);
            return _ds.Tables[0];
        }

        public int GetTotalCount(string machine_num)
        {
            return dao.GetTotalCount(machine_num);
        }

        public int CreateTunnel(string id, string machine_num, string tunnel_num, int tunnel_max_stock, int min_stock_alert, int cur_stock, string material_num)
        {
            DataTable dt = GetItemById(id);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dao.CreateTunnel( id,  machine_num,  tunnel_num,  tunnel_max_stock,  min_stock_alert,  cur_stock,  material_num);
            }
            else
            {
                return dao.UpdateTunnel(id, machine_num, tunnel_num, tunnel_max_stock, min_stock_alert, cur_stock, material_num);
            }

        }

        public DataTable GetItemById(string id)
        {
            return dao.GetItemById(id);
        }

        public int DeleteTunnel(string id)
        {
            return dao.DeleteTunnel(id);
        }

        public DataTable GetMachines()
        {
            return dao.GetMachines();
        }

        public DataTable GetMaterials()
        {
            return dao.GetMaterials();
        }
    }
}
