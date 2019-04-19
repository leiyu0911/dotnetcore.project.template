using System;
using System.Collections.Generic;
using System.Text;

namespace Rex.Temp.EF.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
    }
}

