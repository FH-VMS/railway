using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class MaterialManageBll
    {
        MaterialManageDao dao = new MaterialManageDao();
        public DataTable GetAll(string serial_num,string material_num,int pageIndex, int pageSize)
        {
            DataSet _ds = dao.GetAllMaterials(serial_num, material_num,pageIndex, pageSize);
            return _ds.Tables[0];
        }

        public int GetTotalCount(string serial_num, string material_num)
        {
            return dao.GetTotalCount(serial_num, material_num);
        }

        public int CreateMaterial(string serial_num, string material_num, string material_name, string remark)
        {
            DataTable dt = GetItemById(serial_num);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dao.CreateMaterial(serial_num, material_num, material_name, remark);
            }
            else
            {
                return dao.UpdateMaterial(serial_num, material_num, material_name, remark);
            }

        }

        public DataTable GetItemById(string id)
        {
            return dao.GetItemById(id);
        }

        public int DeleteMaterial(string id)
        {
            return dao.DeleteMaterial(id);
        }
    }
}
