namespace THEIA.Data
{
    namespace Common
    {
        /**
         * A vertex is a pair of coordinates and color.
         * Vertices are linked to skeletons through tags.
         **/
        class Vertex<T1, T2>
        {
            public T1 x { get; set; }
            public T1 y { get; set; }
            public T1 z { get; set; }
            public T2 r { get; set; }
            public T2 g { get; set; }
            public T2 b { get; set; }
            public char tag { get; set; }
        }

        /**
         * A skeleton is a collection of joints positions.
         * Each skeleton has a specific tag attributed by the Kinect.
         **/
        class Skeleton<T1, T2>
        {
            public System.Collections.Generic.Dictionary<JointType, Vertex<T1, T2>> joints { get; set; }
            public char tag { get; set; }
        }

        enum JointType
        {
            AnkleLeft = 14,
            AnkleRight = 18,
            ElbowLeft = 5,
            ElbowRight = 9,
            FootLeft = 15,
            FootRight = 19,
            HandLeft = 7,
            HandRight = 11,
            HandTipLeft = 21,
            HandTipRight = 23,
            Head = 3,
            HipLeft = 12,
            HipRight = 16,
            KneeLeft = 13,
            KneeRight = 17,
            Neck = 2,
            ShoulderLeft = 4,
            ShoulderRight = 8,
            SpineBase = 0,
            SpineMid = 1,
            SpineShoulder = 20,
            ThumbLeft = 22,
            ThumbRight = 24,
            WristLeft = 6,
            WristRight = 10
        }
    }

    namespace FusionServer
    {
        /**
         * A frame may contain multiple skeletons, and an array of vertices.
         * Each frame is timestamped.
         **/
        class FrameData
        {
            public Common.Vertex<ushort, char>[] vertices { get; set; }
            public Common.Skeleton<ushort, char>[] skeleton { get; set; }
            public ulong timestamp { get; set; }
        }
    }

    namespace KinectStreamer
    {
        /**
         * Scatter points as transmitted by the Kinect Streamer
         **/
        class ScatterPoints
        {
            public ulong timestamp { get; set; }
            public Common.Vertex<ushort, char>[] vertices { get; set; }
        }
        
        /**
         * Skeleton as transmited by the KinectStreamer
         **/
        class Skeleton<T1, T2> : Common.Skeleton<T1, T2>
        {
            public ulong timestamp { get; set; }
        }
    }
}
