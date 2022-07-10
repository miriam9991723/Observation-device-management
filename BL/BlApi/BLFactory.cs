﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BlApi
{
    public class BLFactory
    {
        public static IBL GetBL()
        {
            return BL.BL.GetInstance();
        }
    }
}
