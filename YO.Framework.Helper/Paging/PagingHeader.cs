using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YO.Framework.Helper.Paging
{
    public class PagingHeader
    {
        public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages)
        {
            this.TotalItems = totalItems;
            this.Number     = pageNumber;
            this.PageSize   = pageSize;
            this.TotalPages = totalPages;
        }
        public int TotalItems { get; set; }
        public int Number { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, 
                new JsonSerializerSettings 
                { 
                    ContractResolver = new CamelCasePropertyNamesContractResolver() 
                });
        }
    }
}
