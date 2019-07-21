using CorrelationId;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Infra.Log.Loggers
{
    public class LogUtil : ILogUtil
    {
        ICorrelationContextAccessor _correlationContextAccessor;

        public LogUtil(ICorrelationContextAccessor correlationContextAccessor)
        {
            _correlationContextAccessor = correlationContextAccessor;
        }

        public void Information(string information)
        {
            Serilog.Log.ForContext("Operacao", "Processamento", destructureObjects: true)
                       .Information(information);
        }

        public void Error(Exception exception, string errorDescription)
        {
            Serilog.Log.ForContext("Operacao", "Processamento", destructureObjects: true)
                       .Error(exception, errorDescription);
        }

    }
}
