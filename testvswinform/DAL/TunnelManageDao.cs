using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public class TunnelManageDao
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
        public DataSet GetAllTunnels(string machine_num, int pageIndex, int pageSize)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select * from tunnel_manage Where 1=1 ");
            if (!string.IsNullOrEmpty(machine_num))
            {
                sqlstr.Append(" And machine_num like '%" + machine_num + "%' ");
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


        public int GetTotalCount(string machine_num)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(1) from tunnel_manage Where 1=1");
            if (!string.IsNullOrEmpty(machine_num))
            {
                sqlstr.Append(" And machine_num like '%" + machine_num + "%' ");
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
        public int CreateTunnel(string id,string machine_num, string tunnel_num, int tunnel_max_stock, int min_stock_alert, int cur_stock, string material_num)
        {
            int result = 0;
            string sqlstr = "INSERT INTO tunnel_manage(id,machine_num,tunnel_num,tunnel_max_stock,min_stock_alert,cur_stock,material_num) VALUES(@id,@machine_num,@tunnel_num,@tunnel_max_stock,@min_stock_alert,@cur_stock,@material_num)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@id",id),
                    _para = new MySqlParameter("@machine_num",machine_num),
                    _para = new MySqlParameter("@tunnel_num",tunnel_num),
                    _para = new MySqlParameter("@tunnel_max_stock",tunnel_max_stock),
                    _para = new MySqlParameter("@min_stock_alert",min_stock_alert),
                    _para = new MySqlParameter("@cur_stock",cur_stock),
                    _para = new MySqlParameter("@material_num",material_num)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetItemById(string id)
        {
            string sqlstr = "select * from tunnel_manage Where 1=1 AND id='" + id + "'";
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
        public int UpdateTunnel(string id, string machine_num, string tunnel_num, int tunnel_max_stock, int min_stock_alert, int cur_stock, string material_num)
        {
            int result = 0;
            string sqlstr = "UPDATE tunnel_manage SET machine_num=@machine_num,tunnel_num=@tunnel_num,tunnel_max_stock=@tunnel_max_stock,min_stock_alert=@min_stock_alert,cur_stock=@cur_stock,material_num=@material_num WHERE 1=1 AND id=@id";
            try
            {
                MySqlParameter[] _sp ={
                     _para = new MySqlParameter("@id",id),
                     _para = new MySqlParameter("@machine_num",machine_num),
                    _para = new MySqlParameter("@tunnel_num",tunnel_num),
                    _para = new MySqlParameter("@tunnel_max_stock",tunnel_max_stock),
                    _para = new MySqlParameter("@min_stock_alert",min_stock_alert),
                    _para = new MySqlParameter("@cur_stock",cur_stock),
                    _para = new MySqlParameter("@material_num",material_num)
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
        public int DeleteTunnel(string id)
        {
            int result = 0;
            string sqlstr = "DELETE FROM tunnel_manage  WHERE id=@id";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@id",id)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //机器字典
        public DataTable GetMachines()
        {
            string sqlstr = "select id, machine_name from machine_manage Where 1=1";
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

        //物料字典
        public DataTable GetMaterials()
        {
            string sqlstr = "select material_num, material_name from material_manage Where 1=1";
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
    }
}
