using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeAuthomation.Domains.Commons
{
   public class Generator
    {

        public  static  string GenerateGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        
    }
}
