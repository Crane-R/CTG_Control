﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTG_Control.Crane.Service
{
    /// <summary>
    /// 自增服务，只提供一个方法，返回自增ID
    /// </summary>
    internal class IdService
    {

        public static int GenerateId()
        {
            return Convert.ToInt32(ConfigService.GetValue("NextId"));
        }

    }
}
