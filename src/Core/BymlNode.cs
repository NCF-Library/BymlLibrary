using CeadLibrary.IO;

namespace BymlLibrary.Core;

public enum NodeType : byte
{
    String = 0xA0,
    Binary = 0xA1,
    Array = 0xC0,
    Hash = 0xC1,
    StringTable = 0xC2,
    Bool = 0xD0,
    Int = 0xD1,
    Float = 0xD2,
    UInt = 0xD3,
    Int64 = 0xD4,
    UInt64 = 0xD5,
    Double = 0xD6,
    Null = 0xFF,
}

public static class BymlNode
{
    public static void ReadStringTable(this CeadReader reader, long tableOffset, ref List<string> array)
    {
        using (reader.TemporarySeek(tableOffset, SeekOrigin.Begin)) {
            if (reader.ReadEnum<NodeType>() != NodeType.StringTable) {
                throw new InvalidTypeException("Invalid string table node");
            }

            int size = reader.ReadInt24();
            for (int i = 0; i < size; i++) {
                uint offset = reader.ReadUInt32();
                string str = reader.ReadObject(tableOffset + offset, SeekOrigin.Begin, () => reader.ReadString(StringType.ZeroTerminated));
                array.Add(str);
            }
        }
    }
}
