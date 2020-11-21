using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YO.Framework.Helper.Paging.Interface;

namespace YO.Framework.Helper.Paging
{
    public class PagingLinks<T> : IPagingLinks<T>
    {
        private readonly IUrlHelper _urlHelper;
        public LinkInfo CreateLink(string routeName, int pageNumber, int pageSize, string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.Link(routeName,
                            new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }
        public List<LinkInfo> GetLinks(PageList<T> list)
        {
            var links = new List<LinkInfo>();
            if (list.HasPreviousPage)
                links.Add(CreateLink("default", list.PreviousPageNumber,
                           list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("default", list.PageNumber,
                           list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("default", list.NextPageNumber,
                           list.PageSize, "nextPage", "GET"));

            return links;
        }
    }
}
