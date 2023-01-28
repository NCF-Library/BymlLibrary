using System.Runtime.InteropServices;

namespace BymlLibrary.Core;

[StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
public struct BymlUnion
{
    [FieldOffset(0)]
    public bool Bool;

    [FieldOffset(0)]
    public int Int32;

    [FieldOffset(0)]
    public float Float;

    [FieldOffset(0)]
    public uint UInt32;

    public BymlUnion(bool _bool) => Bool = _bool;
    public BymlUnion(int int32) => Int32 = int32;
    public BymlUnion(float _float) => Float = _float;
    public BymlUnion(uint uint32) => UInt32 = uint32;

    public static unsafe BymlUnion FromBinary(Span<byte> data)
    {
        fixed (byte* ptr = data) {
            return Marshal.PtrToStructure<BymlUnion>((IntPtr)ptr);
        }
    }
}
