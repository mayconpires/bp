using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Infra.Log.Loggers
{
    public interface ILogUtil
    {
        void Information(string information);
        void Error(Exception exception, string errorDescription);
    }
}
