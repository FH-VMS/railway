using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testvswinform.Model
{
    class userBean
    {
        #region userBean类的属性（也是表的字段）
        private string _uid;                //操作员编码
        private string _uname;              //操作员名
        private string _uzgbm;              //职工编码
        private string _upasswd;            //密码
        private int    _ugzbz;              //工作标志
        private string _ujrsj;              //进入时间
        private string _ubdsj;              //登记时间
        private string _uszry;              //设置人员
        private int    _ugwlx;              //岗位类型（1：普通工作人员	2：管理员	3：超级用户）
        private int    _uisdl;              //是否登陆(0：不能，1：登陆)
        private string _umemo;              //备注
        #endregion

        public string UId
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string Uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        public string Uzgbm
        {
            get { return _uzgbm; }
            set { _uzgbm = value; }
        }
        public string Upasswd
        {
            get { return _upasswd; }
            set { _upasswd = value; }
        }
        public int  Ugzbz
        {
            get { return _ugzbz; }
            set { _ugzbz = value; }
        }
        public string Ujrsj
        {
            get { return _ujrsj; }
            set { _ujrsj = value; }
        }
        public string Ubdsj
        {
            get { return _ubdsj; }
            set { _ubdsj = value; }
        }
        public string Uszry
        {
            get { return _uszry; }
            set { _uszry = value; }
        }
        public int Ugwlx
        {
            get { return _ugwlx; }
            set { _ugwlx = value; }
        }
        public int Uisdl
        {
            get { return _uisdl; }
            set { _uisdl = value; }
        }
        public string Umemo
        {
            get { return _umemo; }
            set { _umemo = value; }
        }
    }
}
