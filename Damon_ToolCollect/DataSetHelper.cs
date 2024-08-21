using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class DataSetHelper
    {
        /// <summary>
        /// DataSet转换为Json
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToJson(System.Data.DataSet ds)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                json.Append("{");
                json.Append("\"" + ds.Tables[i].TableName + "\":[");
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    json.Append("{");
                    for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                    {
                        json.Append("\"" + ds.Tables[i].Columns[k].ColumnName.ToString() + "\":\"" + ds.Tables[i].Rows[j][k].ToString() + "\"");
                        if (k != ds.Tables[i].Columns.Count - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (j != ds.Tables[i].Rows.Count - 1)
                    {
                        json.Append(",");
                    }
                }
                json.Append("]");
                json.Append("}");
                if (i != ds.Tables.Count - 1)
                {
                    json.Append(",");
                }
            }
            json.Append("]");
            return json.ToString();
        }
        
    }
}
