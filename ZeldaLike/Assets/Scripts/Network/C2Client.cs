using System;
using UnityEngine;

public class C2Client
{
    public C2Session        session;
    public string          nickname { get; set; }
    private MonoBehaviour   player;

    public C2Client(PlayerMovement playerMovement)
    {
        session = new C2Session(this);
        player = playerMovement;
    }

    public void Service()
    {
        session.Service(); // 
    }

    public void SendPakcet<T>(T packet)
    {
        session.SendPacket<T>(packet);
    }



}
