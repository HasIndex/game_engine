

using System;
using System.Runtime.InteropServices;


public enum PacketType : sbyte
{
	PT_NONE,

	C2S_LOGIN = 1,
	C2S_MOVE,

	S2C_LOGIN_OK = 1,
	S2C_MOVE,
	S2C_ENTER,
	S2C_LEAVE,

	PT_MAX,
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct PacketHeader
{
    public sbyte		size;
    public PacketType	type;
}


[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct cs_packet_login
{
    public PacketHeader header;

    public fixed  sbyte name[50];
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct cs_packet_move
{
	public PacketHeader header;

	public char			direction;
	public UInt32		move_time;
};


[StructLayout(LayoutKind.Sequential, Pack = 1)]

public unsafe struct sc_packet_login_ok
{
	public PacketHeader header;

	public int		id;
	public short	x, y;
	public short	hp;
	public short	level;
	public int		exp;
};
[StructLayout(LayoutKind.Sequential, Pack = 1)]

public unsafe struct sc_packet_move
{
	public PacketHeader header;

	public int id;
	public short x, y;
	public UInt32 move_time;
};
[StructLayout(LayoutKind.Sequential, Pack = 1)]

public unsafe struct sc_packet_enter
{
	public PacketHeader header;

	public int id;
	public fixed sbyte name[10];
	public char o_type;
	public short x, y;
};
[StructLayout(LayoutKind.Sequential, Pack = 1)]

public unsafe struct sc_packet_leave
{
	public PacketHeader header;

	public int id;
};
[StructLayout(LayoutKind.Sequential, Pack = 1)]

public unsafe struct sc_packet_chat
{
	public PacketHeader header;

	public int id;
	public fixed sbyte chat[100];
};
