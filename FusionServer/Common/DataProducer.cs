namespace FusionServer.FusionServer.Common
{
    abstract class DataProducer<Type> : ThreadedClass
    {
        private System.Collections.Concurrent.ConcurrentQueue<Type> OutputBuffer;
        
        public bool DataIsAvailable()
        {
            return !this.OutputBuffer.IsEmpty;
        }

        public Type GetAvailableData()
        {
            Type data = default(Type);
            try
            {
                this.OutputBuffer.TryDequeue(out data);
            }
            catch
            {
                
            }
            return data;
        }

        protected void Produce(Type data)
        {
            this.OutputBuffer.Enqueue(data);
        }
    }
}
