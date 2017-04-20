using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public class PeopleManageDao
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
        public DataSet GetAllPeoples(string name, int pageIndex, int pageSize)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select * from people_manage Where 1=1 ");
            if (!string.IsNullOrEmpty(name))
            {
                sqlstr.Append(" And name like '%" + name + "%' ");
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


        public int GetTotalCount(string name)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(1) from people_manage Where 1=1");
            if (!string.IsNullOrEmpty(name))
            {
                sqlstr.Append(" And name like '%" + name + "%' ");
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
        public int CreatePeople(string cardNum, string name, string team, string remark)
        {
            int result = 0;
            string sqlstr = "INSERT INTO people_manage(card_num,name,team,remark) VALUES(@card_num,@name,@team,@remark)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@card_num",cardNum),
                    _para = new MySqlParameter("@name",name),
                    _para = new MySqlParameter("@team",team),
                    _para = new MySqlParameter("@remark",remark)
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
            string sqlstr = "select * from people_manage Where 1=1 AND card_num='" + id + "'";
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
        public int UpdatePeople(string cardNum, string name, string team, string remark)
        {
            int result = 0;
            string sqlstr = "UPDATE people_manage SET name=@name,team=@team,remark=@remark WHERE 1=1 AND card_num=@card_num";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@card_num",cardNum),
                    _para = new MySqlParameter("@name",name),
                    _para = new MySqlParameter("@team",team),
                    _para = new MySqlParameter("@remark",remark)
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
        public int DeletePeople(string cardNum)
        {
            int result = 0;
            string sqlstr = "DELETE FROM people_manage  WHERE card_num=@card_num";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@card_num",cardNum)
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
