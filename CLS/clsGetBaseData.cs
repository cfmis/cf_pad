using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using cf_pad.CLS;

namespace cf_pad.CLS
{
    public class clsGetBaseData
    {
        public static DataTable GetPrdDep()
        {
            string strSql = @" select * from int09 ";

            DataTable dtDept = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            dtDept.Rows.Add();
            dtDept.DefaultView.Sort = "int9loc";
            return dtDept;
        }
        public static DataTable GetDepGroup(string dep,string flag)
        {
            string strSql = "";
            strSql = " SELECT work_group,group_desc FROM work_group WHERE ( dep='" + dep + "'" + " AND group_type='" + flag + "') " + " OR dep='" + "000" + "' ";
            DataTable dtGroup = clsPublicOfPad.ExecuteSqlReturnDataTable(strSql);
            return dtGroup;
        }
    }
}
