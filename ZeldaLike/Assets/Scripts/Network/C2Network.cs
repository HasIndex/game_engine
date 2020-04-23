using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.IO;

public static class C2Network
{
    private static string   gameVersion;
    private static string   appVersion;
    public static string    serverIP { get; } = "127.0.0.1";
    public static Int32     serverPort { get; } = 32321;

    private static Dictionary<Int64, object> sessionMap = new Dictionary<long, object>();


    static C2Network(){}



}
