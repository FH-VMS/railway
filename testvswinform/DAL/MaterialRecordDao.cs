using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public class MaterialRecordDao
    {
        #region SqlDBHelper类
        SqlDBHelper _sh = new SqlDBHelper();
        DataSet _ds;
        private MySqlParameter _para; //参数
        #endregion

        #region 查询所有信息
        ///<summary>
        ///查询所有
        ///</summary>
        ///<returns></returns>
        public DataSet GetAllMaterialRecords(string card_num, string material_num, DateTime time, int pageIndex, int pageSize)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("SELECT a.*,b.`name`,c.material_name FROM material_record a LEFT JOIN people_manage b ON a.card_num=b.card_num LEFT JOIN material_manage c ON a.material_num=c.material_num WHERE 1=1 ");
            if (!string.IsNullOrEmpty(card_num))
            {
                sqlstr.Append(" And (card_num like '%" + card_num + "%') OR b.name like '%" + card_num + "%' ");
            }

            if (!string.IsNullOrEmpty(material_num))
            {
                sqlstr.Append(" And (material_num like '%" + material_num + "%') OR c.material_name like '%" + material_num + "%' ");
            }

            if (!string.IsNullOrEmpty(time.ToString()))
            {
                sqlstr.Append(" And (year('" + time + "')=year(now()) and month('" + time + "')=month(now()) and day('" + time + "')=day(now())) ");
            }

            sqlstr.AppendFormat("Limit {0},{1}", (pageIndex - 1) * pageSize, pageSize);
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds;
        }

        #endregion


        public int GetTotalCount(string card_num, string material_num, DateTime time)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("SELECT count(1) FROM material_record a LEFT JOIN people_manage b ON a.card_num=b.card_num LEFT JOIN material_manage c ON a.material_num=c.material_num WHERE 1=1");
            if (!string.IsNullOrEmpty(card_num))
            {
                sqlstr.Append(" And (card_num like '%" + card_num + "%') OR b.name like '%" + card_num + "%' ");
            }

            if (!string.IsNullOrEmpty(material_num))
            {
                sqlstr.Append(" And (material_num like '%" + material_num + "%') OR c.material_name like '%" + material_num + "%' ");
            }

            if (!string.IsNullOrEmpty(time.ToString()))
            {
                sqlstr.Append(" And (year('" + time + "')=year(now()) and month('" + time + "')=month(now()) and day('" + time + "')=day(now())) ");
            }
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToInt32(_ds.Tables[0].Rows[0][0]);
        }

        //新赠
        public int CreateMaterialRecord(string serial_num, DateTime time, string machine_num, string tunnel_num,string material_num,int totalSum)
        {
            int result = 0;
            string sqlstr = "INSERT INTO material_record(serial_num,time,machine_num,tunnel_num,material_num,sum) VALUES(@serial_num,@time,@machine_num,@tunnel_num,@material_num,@totalSum)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@serial_num",serial_num),
                    _para = new MySqlParameter("@time",time),
                    _para = new MySqlParameter("@machine_num",machine_num),
                    _para = new MySqlParameter("@tunnel_num",tunnel_num),
                    _para = new MySqlParameter("@material_num",material_num),
                    _para = new MySqlParameter("@totalSum",totalSum)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetItemById(string serial_num)
        {
            string sqlstr = "select * from material_record Where 1=1 AND serial_num='" + serial_num + "'";
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds.Tables[0];
        }


        //更新
        public int UpdateMaterialRecord(string serial_num, DateTime time, string machine_num, string tunnel_num, string material_num, int totalSum)
        {
            int result = 0;
            string sqlstr = "UPDATE material_record SET time=@time,machine_num=@machine_num,tunnel_num=@tunnel_num,material_num=@material_num,sum=@totalSum WHERE 1=1 AND serial_num=@serial_num";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@serial_num",serial_num),
                    _para = new MySqlParameter("@time",time),
                    _para = new MySqlParameter("@machine_num",machine_num),
                    _para = new MySqlParameter("@tunnel_num",tunnel_num),
                    _para = new MySqlParameter("@material_num",material_num),
                    _para = new MySqlParameter("@totalSum",totalSum)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //删除
        public int DeleteMaterialRecord(string serial_num)
        {
            int result = 0;
            string sqlstr = "DELETE FROM material_record  WHERE serial_num=@serial_num";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@serial_num",serial_num)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
