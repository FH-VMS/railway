using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class MaterialRecordBll
    {
        MaterialRecordDao dao = new MaterialRecordDao();
        public DataTable GetAll(string card_num, string material_num, DateTime time, int pageIndex, int pageSize)
        {
            DataSet _ds = dao.GetAllMaterialRecords( card_num,  material_num,  time,  pageIndex,  pageSize);
            return _ds.Tables[0];
        }

        public int GetTotalCount(string card_num, string material_num, DateTime time)
        {
            return dao.GetTotalCount(card_num, material_num,time);
        }

        public int CreateMaterial(string serial_num, DateTime time, string machine_num, string tunnel_num, string material_num, int totalSum)
        {
            time = DateTime.Now;
            DataTable dt = GetItemById(serial_num);
            if (dt == null || dt.Rows.Count == 0)
            {
                return dao.CreateMaterialRecord( serial_num,  time,  machine_num,  tunnel_num,  material_num,  totalSum);
            }
            else
            {
                return dao.UpdateMaterialRecord(serial_num, time, machine_num, tunnel_num, material_num, totalSum);
            }

        }

        public DataTable GetItemById(string id)
        {
            return dao.GetItemById(id);
        }

        public int DeleteMaterial(string id)
        {
            return dao.DeleteMaterialRecord(id);
        }
    }
}
