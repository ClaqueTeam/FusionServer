namespace FusionServer.FusionServer.Process
{
    class PassThroughProcessor : FrameProcessor
    {
        public Data.FrameData[] Process(Data.FrameData[] frames)
        {
            return frames;
        }
    }
}