using System;

namespace FusionServer.FusionServer.Processing
{
    class FusionProcessor : FusionServer.Common.DataProducer<FusionServer.Data.FrameData>, FusionServer.Common.IDataConsumer<FusionServer.Data.FrameData>
    {
        protected override void ThreadLoopProcessing()
        {
            throw new NotImplementedException();
        }
    }
}
