using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ControlTool
{
    public class ListViewHelper
    {
        private ListView _listView { get; set; }
        public ListViewHelper(ListView listView)
        {
            _listView = listView;
            _listView.View = View.Details;//设置显示方式
        }
        /// <summary>
        /// DataTable绑定到ListView(返回数量)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int BindDataTable(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            _listView.BeginUpdate();
            _listView.Items.Clear();
            _listView.Columns.Clear();
            foreach (DataColumn dc in dt.Columns)
            {
                _listView.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = dr[0].ToString();
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    lvi.SubItems.Add(dr[i].ToString());
                }
                _listView.Items.Add(lvi);
            }
            //自动调整列宽
            for (int i = 0; i < _listView.Columns.Count; i++)
            {
                _listView.Columns[i].Width = -2;
            }
            _listView.EndUpdate();
            return _listView.Items.Count;
        }
        //隐藏指定列名的列
        public void HideColumn(string columnName)
        {

            if (_listView.Columns.ContainsKey(columnName))
            {
                _listView.Columns[columnName].Width = 0;
            }
        }

    }
}
