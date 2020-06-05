using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class InitialiPacketHandler : C2PacketHandler
{
    public InitialiPacketHandler() : base()
    {
        handlers[(Int32)PacketType.S2C_LOGIN_OK] = LoginOk;
        handlers[(Int32)PacketType.S2C_MOVE] = Move;
        handlers[(Int32)PacketType.S2C_ENTER] = Enter;
        handlers[(Int32)PacketType.S2C_LEAVE] = Leave;
        handlers[(Int32)PacketType.S2C_CHAT] = Chat;

    }

    private void Chat(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        throw new NotImplementedException();

        sc_packet_chat chatPayload;

        payload.Read(out chatPayload);
    }


       // 회원가입
    void LoginOk(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        sc_packet_login_ok loginOkPayload;

        payload.Read(out loginOkPayload);

        C2Session.Instance.uniqueSessionId = (Int64)loginOkPayload.id;
        C2Client.Instance.Player.MoveCharacterUsingServerPostion(loginOkPayload.y, loginOkPayload.x);
    }


    void Enter(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        sc_packet_enter enterPayload;
        payload.Read(out enterPayload);


        
    }

 
    // 이동
    void Move(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        sc_packet_move movePayload;

        payload.Read(out movePayload);
    }

    // 로그인 씬에서 나감. 사실상 연결 끊기.
    void Leave(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        sc_packet_leave leavePayload;

        payload.Read(out leavePayload);
    }

    // login server to my client
    void ResponseLogin(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
    }

    // 회원가입
    void ResponseRegistration(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
    }

    // 로그인 씬에서 나감.
    void ResponseExitLogin(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
    }

}