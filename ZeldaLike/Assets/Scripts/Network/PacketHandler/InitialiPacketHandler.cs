using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InitialiPacketHandler : C2PacketHandler
{
    public InitialiPacketHandler() : base()
    {
        handlers[(Int32)PacketType.S2C_ENTER] = RequestLogin;
        handlers[(Int32)PacketType.S2C_LOGIN_OK] = RequestRegistration;
        handlers[(Int32)PacketType.S2C_LEAVE] = ExitLogin;
    }


    /// <summary>
    ///  this clinet to sserver
    /// </summary>
    void RequestLogin(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
        
    }

    // 회원가입
    void RequestRegistration(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
    }

    // 로그인 씬에서 나감. 사실상 연결 끊기.
    void ExitLogin(PacketHeader header, C2PayloadVector payload, C2Session session)
    {
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