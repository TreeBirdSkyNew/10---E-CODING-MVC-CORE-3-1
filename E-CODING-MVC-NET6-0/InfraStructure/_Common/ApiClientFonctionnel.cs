﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public class ApiClientFonctionnel
    {
        public HttpClient _client { get; private set; }

        public ApiClientFonctionnel(HttpClient client)
        {
            _client = client;
        }
    }
}