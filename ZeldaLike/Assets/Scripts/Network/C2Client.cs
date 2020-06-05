using System;
using UnityEngine;

public class C2Client : Singleton<C2Client>
{
    public C2Session session;
    public string nickname = "default";
    [SerializeField] PlayerMovement player;

    public C2Client(PlayerMovement playerMovement)
    {
        session = C2Session.Instance;
        session.Client = this;
        player = playerMovement;
    }

    public void Start()
    {
        if (session == null)
        {
            session = C2Session.Instance;
            session.Client = this;
        }


        nickname = "default";
    }

    private void Update()
    {
    }


    public void SendPakcet<T>(T packet)
    {
        session.SendPacket<T>(packet);
    }

    public PlayerMovement Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
}
