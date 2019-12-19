using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto.Common
{
    /// <summary>
    /// CommonOrderModel
    /// </summary>
    public class CommonOrderModel
    {
        /// <summary>
        /// 排序名(对就实体类属性名)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序(0 ASC 1 DESC)
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// CommonOrderModel
        /// </summary>
        public CommonOrderModel() { }
        /// <summary>
        /// CommonOrderModel
        /// </summary>
        /// <param name="name">排序名(对就实体类属性名)</param>
        /// <param name="order">排序(0 ASC 1 DESC)</param>
        public CommonOrderModel(string name, int order) { this.Name = name; this.Order = order; }
    }
}
