using System;

namespace FusionServer.FusionServer.IO
{
    class UDPHandler : FusionServer.Common.ThreadedClass
    {
        private string ComponentName;
        private System.Net.IPEndPoint LocalIPEndPoint;
        private System.Net.Sockets.UdpClient UDPConnexion;

        private FusionServer.THEIAProcessing ProcessingPipeline;

        public UDPHandler(string ComponentName, int port, FusionServer.THEIAProcessing ProcessingPipeline)
        {
            this.ComponentName = ComponentName;
            this.LocalIPEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, port);
        }

        public void StartUDPListening()
        {
            this.UDPConnexion = new System.Net.Sockets.UdpClient(this.LocalIPEndPoint);
            this.StartThreadLoop();
        }

        public void StopUDPListening()
        {
            this.StopThreadLoop();
        }

        protected override void ThreadLoopProcessing()
        {
            System.Net.IPEndPoint RemoteIPEndPoint = null;
            byte[] data = this.UDPConnexion.Receive(ref RemoteIPEndPoint);
            System.Net.IPAddress RemoteIP = RemoteIPEndPoint.Address;

            if (!Program.InputProcessors.ContainsKey(RemoteIP))
            {
                Program.BuildProcessingPipeline(RemoteIP);
            }

            FusionServer.Processing.InputProcessor handler;
            Program.InputProcessors.TryGetValue(RemoteIP, out handler);
            handler.Push(this.ComponentName, data);
        }
    }
}
