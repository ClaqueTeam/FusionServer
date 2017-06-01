namespace FusionServer.FusionServer.Process
{
    interface FrameProcessor
    {
        Data.FrameData[] Process(Data.FrameData[] frames);
    }
}