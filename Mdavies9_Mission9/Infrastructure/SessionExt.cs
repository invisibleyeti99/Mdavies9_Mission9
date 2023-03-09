﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Mdavies9_Mission9.Infrastructure
{
    public static class SessionExt
    {

        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
