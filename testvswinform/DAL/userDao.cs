using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using testvswinform.Model;
using testvswinform.Sql;
using MySql.Data.MySqlClient;
namespace testvswinform.DAL
{
    class userDao
    {
        #region SqlDBHelper类
        SqlDBHelper _sh = new SqlDBHelper();
        DataSet _ds;
        private MySqlParameter _para; //参数
        #endregion
        
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <returns></returns>
        public DataSet getLogin(string LoginName, string LoginPwd)
        {
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@name",LoginName),
                    _para = new MySqlParameter("@password",LoginPwd)
                };
                _ds = _sh.GetDataSet(User.LOGIN, _sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds;
        }
        public DataSet getLoginBySql(string LoginName, string LoginPwd)
        {
            string sqlstr="select * from czryk where name='"+LoginName+"' and passwd='"+LoginPwd+"'";
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return _ds;
        }
        #endregion

        #region 查询所有信息
        ///<summary>
        ///查询所有
        ///</summary>
        ///<returns></returns>
        public DataSet getAllUserBySql()
        {
            string sqlstr = "select * from czryk";
            try
            {
                _ds = _sh.GetDataSetBySql(sqlstr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds;
        }

        public DataSet getAllUser()
        {
            try
            {
                _ds = _sh.GetDataSetBySql("Usp_GetAllUsers");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ds;
        }

        #endregion

        //#region 添加用户
        ///// <summary>
        ///// 添加用户
        ///// </summary>
        ///// <param name="_wardB"></param>
        ///// <returns></returns>
        //public int addWardUser(userBean _wardB)
        //{
        //    int _count = 0;
        //    try
        //    {
        //        SqlParameter[] _sp ={
        //            _para = new SqlParameter("@UserId",_wardB.WId),
        //            _para = new SqlParameter("@LoginName",_wardB.WName),
        //            _para = new SqlParameter("@LoginPwd",_wardB.WPwd),
        //            _para = new SqlParameter("@py",_wardB.Pym),
        //            _para = new SqlParameter("@wb",_wardB.Wbm),
        //            _para = new SqlParameter("@qx",_wardB.WQx)
        //        };
        //        _count = _sh.RunSql("Usp_AddWardUser", _sp);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _count;
        //}
        //#endregion

        public int UpdateUser(string id, string name,string password)
        {
            int result = 0;
            string sqlstr = "UPDATE user SET name=@name,password=@password WHERE 1=1 AND id=@id";
            try
            {
                MySqlParameter[] _sp ={
                     _para = new MySqlParameter("@id",id),
                     _para = new MySqlParameter("@name",name),
                    _para = new MySqlParameter("@password",password)
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
