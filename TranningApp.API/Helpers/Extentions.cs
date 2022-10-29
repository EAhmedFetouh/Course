using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranningApp.API.Helpers
{
    public static class Extentions
    {
        public static void AddApplicationError (this HttpResponse response, string Message){
            response.Headers.Add("Application-Error",Message);
            response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }
        
    }
}