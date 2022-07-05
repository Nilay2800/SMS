﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
   public class BaseProvider : IDisposable
    {
        public SMSEntites _db;
        public BaseProvider()
        {
            _db = new SMSEntites();

        }
        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
