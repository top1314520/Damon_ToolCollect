namespace Damon_ControlTool
{
    public class ComboBoxHelper
    {
        private ComboBox _comboBox { get; set; }
        public ComboBoxHelper(ComboBox comboBox)
        {
            _comboBox = comboBox;
        }
        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(string item)
        {
            _comboBox.Items.Add(item);
        }
        /// <summary>
        /// 添加多项
        /// </summary>
        /// <param name="items"></param>
        public void AddItems(List<string> items)
        {
            _comboBox.Items.AddRange(items.ToArray());
        }
        /// <summary>
        /// 移除项
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(string item)
        {
            _comboBox.Items.Remove(item);
        }
        /// <summary>
        /// 移除项
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            _comboBox.Items.RemoveAt(index);
        }
        /// <summary>
        /// 关闭下拉框
        /// </summary>
        public void Clear()
        {
            _comboBox.Items.Clear();
        }
    }
}
