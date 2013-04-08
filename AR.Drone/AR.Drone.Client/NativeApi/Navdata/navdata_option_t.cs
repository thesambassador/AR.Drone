using System.Runtime.InteropServices;

namespace AR.Drone.NativeApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct navdata_option_t
    {
        public ushort tag;
        public ushort size;
        // public byte* data; no need to map will be processed manually
    }
}