using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.IO;
using UnityEngine;

public class NetworkManager : Singleton<NetworkManager>
{
    private static NetworkManager    instance; // = new C2Network();
    private static string       gameVersion = "for testing";
    private static string       appVersion = "alpha";
    public static string        serverIP { get; } = "127.0.0.1";
    public static Int32         serverPort { get; } = 9000;

    private static Dictionary<Int64, object> otherMap = new Dictionary<long, object>();
    internal C2Client               client;
    [SerializeField] PlayerMovement player;

    void Start()
    {
        Debug.Log("Network Manager");
        LoadConfigUsingJson();
        client = new C2Client(player);
    }

    private void Update()
    {
        client.Service(); 
    }

    private void LoadConfigUsingJson()
    {
        
    }


}
