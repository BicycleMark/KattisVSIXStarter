﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace ConoleLogin
{
    class Program
    {
        public class ClientConfig
        {
            public string script { get; set; } = "true";
            public string user { get; set; } = "mark-wardell";
            public string token { get; set; } = "aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df";
            

        }
        static
            async Task<int> Main(string[] args)
        {
           var b = await Login("mark.d.wardell@gmail.com", "Atlanta1960!");
            return 0;
        }

        static async Task<bool> Login( string user, string pwd)
        {
            var client = new RestClient("https://open.kattis.com");
            var req = new RestRequest("/login", Method.POST);
            var config = new ClientConfig();//values to pass in request

            // Content type is not required when adding parameters this way
            // This will also automatically UrlEncode the values
            //req.AddBody(config);
            req.AddParameter("script", config.script, ParameterType.GetOrPost);
            req.AddParameter("token", config.token, ParameterType.GetOrPost);
            req.AddParameter("user", config.user, ParameterType.GetOrPost);


            var res = client.Execute(req);
            await Task.Delay(10);
            return true;
        }
    }
}
