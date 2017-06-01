namespace FusionServer.FusionServer.IO.UDP
{
    class InputHandler : Common.ThreadProcess
    {
        private System.Net.Sockets.Socket socket;
        private System.Collections.Concurrent.ConcurrentQueue<Data.FrameData> queue;

        public bool Connect(string ip, int port)
        {
            throw new System.NotImplementedException(); // UDP
        }

        public Data.FrameData getNextFrame()
        {
            throw new System.NotImplementedException();
        }

        // creates a new thread that executes the 'LoopProcessing' method in loop
        public void StartSocketListening()
        {
            if (this.socket != null)
            {
                this.StartThread();
            }
            else
            {
                System.Console.Write("Trying to listen on an uninitialized socket... ");
            }
        }

        // stops the thread that executes the 'LoopProcessing' method in loop
        public void StopSocketListening()
        {
            this.StopThread();
        }

        protected override void LoopProcessing()
        {
            byte[] buffer = new buffer[];

            this.socket.Receive(buffer);
            throw new System.NotImplementedException();
        }
    }
}