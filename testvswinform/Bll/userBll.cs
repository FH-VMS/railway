using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using testvswinform.DAL;
using testvswinform.Model;
using System.Data;

namespace testvswinform.Bll
{
    class userBll : CommonBll
    {
        #region 连接数据层
        userDao _userD = new userDao();
        #endregion

        #region 用户登录check by proc
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <returns></returns>
        public userBean GetLoginBllProc(string LoginName, string LoginPwd)
        {
            userBean _userBean = null;
            DataSet _dsGetLogin = _userD.getLogin(LoginName, LoginPwd);
            foreach (DataRow _dr in _dsGetLogin.Tables[0].Rows)
            {
                _userBean = new userBean();
                _userBean.UId = _dr["id"].ToString().Trim();
                _userBean.Uname = _dr["name"].ToString().Trim();
                /*
                _userBean.Uzgbm = _dr["zgbm"].ToString().Trim();
                _userBean.Upasswd = _dr["passwd"].ToString();
                _userBean.Ugzbz = Convert.ToInt16(_dr["gzbz"]);
                _userBean.Ujrsj = _dr["jrsj"].ToString().Trim();
                _userBean.Ubdsj = _dr["bdsj"].ToString().Trim();
                _userBean.Uszry = _dr["szry"].ToString().Trim();
                _userBean.Ugwlx = Convert.ToInt16(_dr["gwlx"]);
                _userBean.Uisdl = Convert.ToInt16(_dr["isdl"]);
                _userBean.Umemo = _dr["memo"].ToString().Trim();
                 * */
                //return _userBean;
            }
            return _userBean;
            /*
            int _count = _dsGetLogin.Tables[0].Rows.Count;
            if (_count > 0)
                return true;    //表示用户名和密码正确
            return false;       //表示用户名或密码不正确
            */
        }
        #endregion
        #region 用户登录check by SQL
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <returns></returns>
        public userBean GetLoginBllSql(string LoginName, string LoginPwd)
        {

            userBean _userBean = null;
            DataSet _dsGetLogin = _userD.getLoginBySql(LoginName, LoginPwd);
            foreach (DataRow _dr in _dsGetLogin.Tables[0].Rows)
            {
                _userBean = new userBean();
                _userBean.UId = _dr["id"].ToString().Trim();
                _userBean.Uname = _dr["name"].ToString().Trim();
                _userBean.Uzgbm = _dr["zgbm"].ToString().Trim();
                _userBean.Upasswd = _dr["passwd"].ToString();
                _userBean.Ugzbz = Convert.ToInt16(_dr["gzbz"]);
                _userBean.Ujrsj = _dr["jrsj"].ToString().Trim();
                _userBean.Ubdsj = _dr["bdsj"].ToString().Trim();
                _userBean.Uszry = _dr["szry"].ToString().Trim();
                _userBean.Ugwlx = Convert.ToInt16(_dr["gwlx"]);
                _userBean.Uisdl = Convert.ToInt16(_dr["isdl"]);
                _userBean.Umemo = _dr["memo"].ToString().Trim();
                //return _userBean;
            }
            return _userBean;
            /*
            int _count = _dsGetLogin.Tables[0].Rows.Count;
            if (_count > 0)
                return true;    //表示用户名和密码正确
            return false;       //表示用户名或密码不正确
            */
        }
        #endregion
        #region 查询所有用户
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<userBean> GetAllUsersBll()
        {
            List<userBean> _lstwuser = new List<userBean>();
            DataSet _ds = _userD.getAllUser();
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                userBean _userBean = new userBean();
                _userBean.UId = _dr["id"].ToString().Trim();
                _userBean.Uname = _dr["name"].ToString().Trim();
                _userBean.Uzgbm = _dr["zgbm"].ToString().Trim();
                _userBean.Upasswd = _dr["passwd"].ToString().Trim();
                _userBean.Ugzbz = Convert.ToInt16(_dr["gzbz"]);
                _userBean.Ujrsj = _dr["jrsj"].ToString().Trim();
                _userBean.Ubdsj = _dr["bdsj"].ToString().Trim();
                _userBean.Uszry = _dr["szry"].ToString().Trim();
                _userBean.Ugwlx = Convert.ToInt16(_dr["gwlx"]);
                _userBean.Uisdl = Convert.ToInt16(_dr["isdl"]);
                _userBean.Umemo = _dr["memo"].ToString().Trim();
                _lstwuser.Add(_userBean);
            }

            return _lstwuser;
        }
        #endregion


        public int UpdateUser(string id, string name,string password)
        {
            return _userD.UpdateUser(id, name, password);
        }
    }
}
