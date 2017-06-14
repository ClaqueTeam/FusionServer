namespace FusionServer.FusionServer.Common
{
    abstract class ThreadedClass
    {
        private volatile bool Running;
        private volatile System.Threading.Thread ThreadInstance;

        protected void StartThreadLoop()
        {
            if (!this.Running && this.ThreadInstance == null)
            {
                this.Running = true;
                this.ThreadInstance = new System.Threading.Thread(new System.Threading.ThreadStart(this.Loop));
            }
        }

        protected void StopThreadLoop()
        {
            this.Running = false;
        }

        protected void WaitForThreadLoopToStop()
        {
            this.ThreadInstance.Join();
        }

        protected bool IsRunning()
        {
            return this.Running;
        }

        private void Loop()
        {
            while (this.Running)
            {
                this.ThreadLoopProcessing();
            }
            this.ThreadInstance = null;
        }

        abstract protected void ThreadLoopProcessing();
    }
}
