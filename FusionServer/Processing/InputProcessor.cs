using System;

namespace FusionServer.FusionServer.Processing
{
    class InputProcessor : FusionServer.Common.DataProducer<FusionServer.Data.FrameData>
    {
        private System.Collections.Generic.Dictionary<string, System.Collections.Concurrent.ConcurrentQueue<byte[]>> NetworkInputQueues;

        public void Push(string component, byte[] data)
        {
            if (!this.NetworkInputQueues.ContainsKey(component))
            {
                this.NetworkInputQueues.Add(component, new System.Collections.Concurrent.ConcurrentQueue<byte[]>());
            }

            System.Collections.Concurrent.ConcurrentQueue<byte[]> queue;
            this.NetworkInputQueues.TryGetValue(component, out queue);
            queue.Enqueue(data);
        }

        protected override void ThreadLoopProcessing()
        {
            throw new NotImplementedException();
            foreach (string component in this.NetworkInputQueues.Keys)
            {

            }

            int nbComponents;
            
            // NEED PROOF READING

            ulong previous_timestamp;
            ulong current_timestamp;
            ulong next_timestamp;
            bool data_to_process = false;

            for (int i = 0; i < nbComponents; i++)
            {
                if (tmp[i] == null)
                {
                    tmp[i] = inputQueue[i].dequeue();
                    if (tmp[i] != null)
                    {
                        data_to_process = true;
                        if (tmp[i].timestamp < current_timestamp)
                        {
                            next_timestamp = current_timestamp;
                            current_timestamp = tmp[i].timestamp;
                        }
                        else if (tmp[i].timestamp < next_timestamp)
                        {
                            next_timestamp = tmp[i].timestamp;
                        }
                    }
                }
            }
            if (data_to_process)
            {
                if (current_timestamp > previous_timestamp)
                {
                    // produce data from buffer
                    // clear buffer
                }

                for (int i = 0; i < nbComponents; i++)
                {
                    if (tmp[i].timestamp == current_timestamp)
                    {
                        buffer[i].add(tmp[i]);
                        tmp[i] = null;
                    }
                }

                current_timestamp = next_timestamp;
                next_timestamp = current_timestamp + 1000; // arbitrary increment
                data_to_process = false;
            }

        }
    }
}
