using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testvswinform.DAL
{
    public  class MaterialManageDao
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
        public DataSet GetAllMaterials(string materialNum, string materialName,int pageIndex, int pageSize)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select * from material_manage Where 1=1 ");
            if (!string.IsNullOrEmpty(materialNum))
            {
                sqlstr.Append(" And material_num like '%" + materialNum + "%' ");
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                sqlstr.Append(" And material_name like '%" + materialName + "%' ");
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


        public int GetTotalCount(string materialNum, string materialName)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(1) from material_manage Where 1=1");
            if (!string.IsNullOrEmpty(materialNum))
            {
                sqlstr.Append(" And material_num like '%" + materialNum + "%' ");
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                sqlstr.Append(" And material_name like '%" + materialName + "%' ");
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
        public int CreateMaterial(string serial_num,string material_num, string material_name, string remark)
        {
            int result = 0;
            string sqlstr = "INSERT INTO material_manage(serial_num,material_num,material_name,remark) VALUES(@serial_num,@material_num,@material_name,@remark)";
            try
            {
                MySqlParameter[] _sp ={
                    _para = new MySqlParameter("@serial_num",serial_num),
                    _para = new MySqlParameter("@material_num",material_num),
                    _para = new MySqlParameter("@material_name",material_name),
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

        public DataTable GetItemById(string serial_num)
        {
            string sqlstr = "select * from material_manage Where 1=1 AND serial_num='" + serial_num + "'";
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
        public int UpdateMaterial(string serial_num, string material_num, string material_name, string remark)
        {
            int result = 0;
            string sqlstr = "UPDATE material_manage SET material_num=@material_num,material_name=@material_name,remark=@remark WHERE 1=1 AND serial_num=@serial_num";
            try
            {
                MySqlParameter[] _sp ={
                     _para = new MySqlParameter("@serial_num",serial_num),
                    _para = new MySqlParameter("@material_num",material_num),
                    _para = new MySqlParameter("@material_name",material_name),
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
        public int DeleteMaterial(string serial_num)
        {
            int result = 0;
            string sqlstr = "DELETE FROM material_manage  WHERE serial_num=@serial_num";
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
