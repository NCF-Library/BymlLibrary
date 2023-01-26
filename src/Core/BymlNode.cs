using CeadLibrary.IO;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace BymlLibrary.Core;

public static class BymlNode
{
    public static void ReadStringTable(this CeadReader reader, long tableOffset, ref List<string> array)
    {
        using (reader.TemporarySeek(tableOffset, SeekOrigin.Begin)) {
            int size = reader.ReadInt32() & 0x00FFFFFF;
            for (int i = 0; i < size; i++) {
                uint offset = reader.ReadUInt32();
                string str = reader.ReadObject(tableOffset + offset, SeekOrigin.Begin, () => reader.ReadString(StringType.ZeroTerminated));
                array.Add(str);
            }
        }
    }
}
