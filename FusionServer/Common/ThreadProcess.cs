namespace FusionServer.FusionServer.Common
{
    abstract class ThreadProcess
    {
        private volatile bool active;
        private volatile System.Threading.Thread threadInstance;

        protected void StartThread()
        {
            if (!this.active && this.threadInstance == null)
            {
                this.active = true;
                this.threadInstance = new System.Threading.Thread(new System.Threading.ThreadStart(this.Loop));
            }
        }

        protected void StopThread()
        {
            this.active = false;
        }

        private void Loop()
        {
            while (this.active)
            {
                this.LoopProcessing();
            }
            this.threadInstance = null;
        }

        abstract protected void LoopProcessing();
    }
}
