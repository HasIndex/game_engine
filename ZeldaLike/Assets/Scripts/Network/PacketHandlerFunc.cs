using JetBrains.Annotations;
using System;
using System.Diagnostics.Tracing;

public delegate void PacketHandlerFunc(PacketHeader header, C2PayloadVector payload, C2Session session);

public class C2PacketHandler
{
    public static PacketHandlerFunc[] handlers = new PacketHandlerFunc[(Int32)PacketType.MAX];

    public C2PacketHandler()
    {
        for(int n = 0; n < (int)PacketType.MAX; ++n)
        {
            handlers[n] = DoDefualutHandler;
        }
    }

    void DoDefualutHandler(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        throw new NotImplementedException();
    }

    public PacketHandlerFunc this[PacketType type]
    {
        get 
        {
            if(PacketType.NONE < type && type < PacketType.MAX)
                return C2PacketHandler.handlers[(int)type];
            else
                throw new IndexOutOfRangeException();
        }
    }
}


public class InitialiPacketHandler : C2PacketHandler
{
    public InitialiPacketHandler() : base()
    {
        handlers[(Int32)PacketType.HI] = HiRequest;
    }

    void HiRequest(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        HiPacket hi = new HiPacket();
        ByePacket bye = new ByePacket();

        payload.Read<HiPacket>(out hi);
        payload.Read<ByePacket>(out bye);

    }
} 





public class InGamePacketHandler : C2PacketHandler
{
    public InGamePacketHandler() : base()
    {
    }
}
