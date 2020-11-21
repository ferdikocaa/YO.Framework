using System.Collections.Generic;

namespace YO.Framework.Helper.Paging
{
    public class OutPutModel<T>
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<T> Items { get; set; }
    }
}
