using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeAuthomation.Domains.Commons
{
   public  class BaseEntity
    {
        public Guid Id { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
