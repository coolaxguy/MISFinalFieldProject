using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUFitRecWebApp
{
    public static class Session
    {
        public static int CurrentUserID { get; set; }
        public static string Username { get; set; }
    }
}
