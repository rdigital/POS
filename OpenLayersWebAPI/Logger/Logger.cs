using System;
using log4net;
namespace OpenLayersWebAPI.Logger
{
    public static class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Logger));

        public static void LogInfo(string info)
        {
            string name = Log.Logger.Name;
            Log.DebugFormat(info);
        }

    }
}