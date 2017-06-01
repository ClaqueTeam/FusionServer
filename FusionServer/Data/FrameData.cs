
namespace FusionServer.FusionServer.Data
{
    struct Vector3<T>
    {
        T x;
        T y;
        T z;
    }

    struct Color3<T>
    {
        T r;
        T g;
        T b;
    }

    struct Vertex<T>
    {
        public Vector3<T> position { get; set; }
        public Color3<T> color { get; set; }
    }

    struct FrameData
    {
        public Vertex<float>[] vertices;
        // public ? skeleton
    }
}
