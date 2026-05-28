using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Dummy.OperationalManager
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Error(string error);
        void Info(string message);
    }
}
