using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testvswinform.DAL;

namespace testvswinform.Bll
{
    public class SystemSettingBll
    {
        SystemSettingDao dao = new SystemSettingDao();
        public DataTable GetAll()
        {
            return dao.GetAll();
        }

        public int Create(string paramter)
        {
            DataTable dt = dao.GetAll();
            if (dt.Rows.Count > 0)
            {
                return dao.Update(paramter);
            }
            else
            {
                return dao.Create(paramter);
            }
          
        }
    }
}
