using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class CommonMessages
    {
        public static string RequiredMessages(this string message)
        {
            message = "You are required to fill out the section,please try again";
            return message;
        }

    }
}
