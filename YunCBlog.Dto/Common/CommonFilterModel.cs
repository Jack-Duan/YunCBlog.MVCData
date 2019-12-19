using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto.Common
{
    /// <summary>
    /// CommonFilterModel
    /// </summary>
    public class CommonFilterModel
    {
        /// <summary>
        /// CommonFilterModel
        /// </summary>
        public CommonFilterModel() { }

        /// <summary>
        /// CommonFilterModel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filter"></param>
        /// <param name="value"></param>
        public CommonFilterModel(string name, string filter, string value) { this.Name = name; this.Filter = filter; this.Value = value; }

        /// <summary>
        /// CommonFilterModel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filter"></param>
        /// <param name="values"></param>
        public CommonFilterModel(string name, string filter, List<object> values) { this.Name = name; this.Filter = filter; this.ListValue = values; }
        /// <summary>
        /// 字段名(对就实体类属性名)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 查询条件(=>....like in not in)
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 用来查询的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 采用In时的列表数据
        /// </summary>
        public List<object> ListValue { get; set; }
    }
}
