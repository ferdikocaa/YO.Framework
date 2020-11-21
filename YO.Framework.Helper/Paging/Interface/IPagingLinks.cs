using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YO.Framework.Helper.Paging.Interface
{
    public interface IPagingLinks<T>
    {
        List<LinkInfo> GetLinks(PageList<T> list);
        LinkInfo CreateLink(string routeName, int pageNumber, int pageSize, string rel, string method);
    }
}
