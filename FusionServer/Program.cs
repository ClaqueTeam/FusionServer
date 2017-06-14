using System;
using System.Net;

namespace FusionServer.FusionServer
{
    class Program
    {
        public static System.Collections.Generic.Dictionary<System.Net.IPAddress, FusionServer.Processing.InputProcess> InputProcessors;

        internal static void BuildProcessingPipeline(IPAddress remoteIP)
        {
            throw new NotImplementedException();
        }
    }
}