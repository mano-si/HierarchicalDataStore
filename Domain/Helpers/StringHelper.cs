﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Helpers
{
    public static class StringHelper
    {
        public static string[] ParseString(string path)
        {
            path.Substring(1);

            string[] list = path.Split('/');

            return list;
        }

    }
}
