using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public class SystemSettingDao
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
        public DataTable GetAll()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select * from system_setting Where 1=1 ");
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds.Tables[0];
        }

        #endregion

        //更新
        public int Update(string parameter)
        {
            int result = 0;
            string sqlstr = "UPDATE system_setting SET parameter=@parameter";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@parameter",parameter)
                };
                result = _sh.RunSql(sqlstr, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public int Create(string parameter)
        {
            int result = 0;
            string sqlstr = "Insert into system_setting(parameter) Values(@parameter)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@parameter",parameter)
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
