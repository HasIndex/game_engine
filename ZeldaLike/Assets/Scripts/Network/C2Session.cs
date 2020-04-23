using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Reflection;
using System.CodeDom;

enum SessionState
{
    BEFORE_INIT,
    AFTER_INIT,
    CONNECTING,
    CONNECTED,
    DISCONNECTED,
}


public class C2Session
{
    Socket          socket      = new Socket(SocketType.Stream, ProtocolType.Tcp);
    C2PayloadVector   recvBuffer  = new C2PayloadVector();
    C2PayloadVector   sendBuffer  = new C2PayloadVector();
    Int64           recvBytes;
    Int64           sendBytes;
    SessionState    state       = SessionState.BEFORE_INIT;
    Int64           uniqueSessionId;
    C2PacketHandler   handler     = new InitialiPacketHandler();

    C2Session()
    {
        OnInit();
    }

    private void OnInit()
    {
        this.state = SessionState.AFTER_INIT;
    }


    public void Connect()
    {
        socket.BeginConnect(C2Network.serverIP, C2Network.serverPort, null, null);
    }

    public void SendPayload()
    {
        if(sendBuffer.Empty) // 보낼것 없으면...
        {
            return;
        }

        socket.Send(sendBuffer.GetBuffer(), sendBuffer.ReadHead, sendBuffer.Size, SocketFlags.None);
    }

    public void RecvPayload()
    {
        if (true == socket.Poll(0, SelectMode.SelectRead) )
        {
            SocketError error;
            Int32 receivedBytes = socket.Receive(recvBuffer.GetBuffer(), recvBuffer.WriteHead, recvBuffer.FreeSize, SocketFlags.None, out error);
            if(0 < receivedBytes)
            {
                recvBuffer.MoveWriteHead(receivedBytes);

                OnRecv();
            }
        }
    }

    public void OnRecv()
    {
        PacketHeader header = default;
        Int32 headerSize = Marshal.SizeOf<PacketHeader>();
        Int32 readBytes = 0;

        for (;;)
        {
            if ( headerSize != recvBuffer.Peek<PacketHeader>(out header, headerSize) )
                break;

            if(header.size > recvBuffer.Size)
                break;

            // 범위 체크..
            handler[header.type](header, this.recvBuffer, this);

            recvBuffer.MoveReadHead(readBytes);
        }

        recvBuffer.Rewind();
    }

    public void ParsePacket(PacketHeader header)
    {
        switch (header.type)
        {
            case PacketType.HI:
            {
                HiPacket hi = default;



                break;
            }
        }
    }

}
