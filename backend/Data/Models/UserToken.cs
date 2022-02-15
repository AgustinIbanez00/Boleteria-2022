using System;
using System.Collections.Generic;
using System.Text;

namespace BoleteriaOnline.Web.Data.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
