using System;
using System.Collections.Generic;
using System.Text;

namespace Rex.Temp.BusinessModel
{
    public class PagingModel<T>
        where T : class
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总量
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// 当前页数据
        /// </summary>
        private IList<T> PageData { get; set; }
    }
}
