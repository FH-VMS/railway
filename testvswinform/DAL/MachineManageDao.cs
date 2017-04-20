using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public class MachineManageDao
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
        public DataSet GetAllMachines(int pageIndex, int pageSize)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select * from machine_manage Where 1=1 ");
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


        public int GetTotalCount()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(1) from machine_manage Where 1=1");
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
        public int CreateMachine(string id, string machine_type, string describe, string machine_name)
        {
            int result = 0;
            string sqlstr = "INSERT INTO machine_manage(id,machine_type,remark,machine_name) VALUES(@id,@machine_type,@remark,@machine_name)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@id",id),
                    _para = new MySqlParameter("@machine_type",machine_type),
                    _para = new MySqlParameter("@remark",describe),
                    _para = new MySqlParameter("@machine_name",machine_name)
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
            string sqlstr = "select * from machine_manage Where 1=1 AND id='" + id + "'";
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
        public int UpdateMachine(string id, string machine_type, string describe, string machine_name)
        {
            int result = 0;
            string sqlstr = "UPDATE machine_manage SET machine_type=@machine_type,remark=@remark, machine_name=@machine_name WHERE 1=1 AND id=@id";
            try
            {
                MySqlParameter[] _sp ={
                     _para = new MySqlParameter("@id",id),
                    _para = new MySqlParameter("@machine_type",machine_type),
                    _para = new MySqlParameter("@remark",describe),
                    _para = new MySqlParameter("@machine_name",machine_name)
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
        public int DeleteMachine(string id)
        {
            int result = 0;
            string sqlstr = "DELETE FROM machine_manage  WHERE id=@id";
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
    }
}
