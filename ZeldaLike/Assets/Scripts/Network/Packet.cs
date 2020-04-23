using System;


public enum PacketType : Int16
{
    NONE 
    ,HI
    ,BYE
    ,MAX
}


public struct PacketHeader
{
    public Int16       size;
    public PacketType  type;
}


public struct HiPacket
{
    public PacketHeader header;

    Int32 id;
}


public struct ByePacket
{
    public PacketHeader header;

    Int32 id;
}
