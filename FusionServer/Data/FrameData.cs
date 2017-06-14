namespace FusionServer.FusionServer.Data
{
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
    
    /**
     * A vertex is a pair of coordinates and color.
     * Vertices are linked to skeletons through tags.
     **/
    class Vertex<T1, T2>
    {
        T1 x;
        T1 y;
        T1 z;
        T2 r;
        T2 g;
        T2 b;
        char tag;
    }

    /**
     * A skeleton is a collection of joints positions.
     * Each skeleton has a specific tag attributed by the Kinect.
     **/
    class Skeleton<T1, T2>
    {
        System.Collections.Generic.Dictionary<JointType, Vertex<T1, T2>> joints;
        char tag;
    }

    /**
     * A frame may contain multiple skeletons, and an array of vertices.
     * Each frame is timestamped.
     **/
    struct FrameData
    {
        public Vertex<ushort, char>[] vertices;
        public Skeleton<ushort, char>[] skeleton;
        public ulong timestamp;
    }
}
