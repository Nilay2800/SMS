using SMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class BaseProvider : IDisposable
    {

        public SMSContext _db;
        public BaseProvider()
        {
            _db = new SMSContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
