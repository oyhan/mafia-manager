using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia
{
    public static class Logger
    {
        public static ILogger logger;

        public static void Log(string message)
        {
            logger.LogInformation(message);
        }
    }
}
