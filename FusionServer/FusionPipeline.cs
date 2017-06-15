namespace FusionServer.FusionServer
{
    class THEIAProcessing
    {
        public System.Collections.Generic.List<FusionServer.IO.UDPHandler> PortHandlers { get; }
        public System.Collections.Generic.Dictionary<System.Net.IPAddress, FusionServer.Processing.InputProcessor> InputHandlers { get; }
        public FusionServer.Processing.FusionProcessor FusionHandler { get; }
        public FusionServer.Processing.OutputProcessor OutputHandler { get; }
        public FusionServer.IO.MultipleRTCHandler RTCHandler { get; }



        public void AddUDPListener(string component, int port)
        {
            this.PortHandlers.Add(new FusionServer.IO.UDPHandler(component, port, ref this));
        }

        public void AddKinect(System.Net.IPAddress address)
        {
            FusionServer.Processing.InputProcessor processor = new FusionServer.Processing.InputProcessor();
            this.InputHandlers.Add(address, processor);
        }
    }
}
