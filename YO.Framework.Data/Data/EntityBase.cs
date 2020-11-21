using System;
using YO.Framework.Common.Enums;

namespace YO.Framework.Dal.Data
{
    public class EntityBase
    {
        public Guid CreatedBy { get; set; }
        public DateTime? CreatedDate { 
            get { return CreatedDate; } 
            set { CreatedDate = DateTime.UtcNow; } 
        }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public AppStatus? Status {
            get { return Status; }
            set { Status = value ?? AppStatus.Active; }
        }

    }
}
